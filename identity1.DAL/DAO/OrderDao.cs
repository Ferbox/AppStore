using System.Collections.Generic;
using System.Linq;
using identity1.Common.EF;
using identity1.Common.Entities;
using identity1.DALContracts;
namespace identity1.DAL.DAO
{
    public class OrderDao:IOrderDao
    {
        ApplicationDbContext DbContext = new ApplicationDbContext();
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

        public IEnumerable<Product> GetOrderList(int[] productidFromSession)
        {
            var ordlist = from p in DbContext.Products
                          join i in DbContext.Images on p.ProductId equals i.ProductId
                          where productidFromSession.Contains(p.ProductId) && ( i.Name == "logo" )
                          select p;
            for (int i = 0;i < productidFromSession.Length;i++)
            {
                foreach (var item in ordlist)
                {
                    if (productidFromSession[i] == item.ProductId)
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}
