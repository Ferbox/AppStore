using System.Linq;
using System.Collections.Generic;
using identity1.Common.Entities;
using identity1.DALContracts;
using identity1.Common.EF;
using System.Data.Entity;

namespace identity1.DAL.DAO
{
    public class ProductsDao:IProductDao
    {

        private ApplicationDbContext DbContext = new ApplicationDbContext();

        public Product GetProduct(int id)
        {
            var product = DbContext.Products.Include(p => p.Images).FirstOrDefault(x => x.ProductId == id);
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
                yield return DbContext.Products.FirstOrDefault(p => p.ProductId == id);
            }
        }
    }
}

