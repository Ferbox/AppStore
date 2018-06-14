using System.Linq;
using System.Collections.Generic;
using identity1.Common.Entities;
using identity1.DALContracts;
using identity1.Common.EF;
using System.Data.Entity;
using System.Threading.Tasks;
using System;

namespace identity1.DAL.DAO
{
    public class ProductsDao:IProductDao
    {
        private ApplicationDbContext DbContext = new ApplicationDbContext();
        public async Task<Product> GetProduct(int id)
        {
            var product = await DbContext.Products.Include(p => p.Images).FirstOrDefaultAsync(x => x.ProductId == id);
            return product;
        }
        public IEnumerable<Product> GetProducts(int type)
        {
            var pr = DbContext.Products.GroupBy(p => p.Title).Select(y => y.FirstOrDefault());

            return pr;
            
        }
        public IEnumerable<Product> GetProducts(int[] idProducts)
        {
            foreach (int id in idProducts)
            {
                yield return DbContext.Products.Include(x => x.Images).FirstOrDefault(p => p.ProductId == id);
            }
        }
        public void CreateOrder(Order order, string id, int[] orderlist, int[] qty)
        {
            order.UserId = id;
            for (int i = 0;i < orderlist.Length;i++)
            {
                DbContext.OrderItem.Add(new OrderItem { OrderId = order.OrderId, ProductId = orderlist[i], Quantity = qty[i] });
            }
            DbContext.Orders.Add(order);
            DbContext.SaveChanges();
        }


    }
}

