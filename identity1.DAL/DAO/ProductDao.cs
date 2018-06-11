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

        public IEnumerable<Product> GetProductsForCatalog(int type)
        {
            return DbContext.Products.Where(x => x.TypeId == type).Include(x => x.Images).ToList();
        }

        public Product GetProduct(int id)
        {
            var product = DbContext.Products.Include(p => p.Images).FirstOrDefault(x => x.ProductId == id);
            return product;
        }

        public IEnumerable<Product> GetProductsForCart(int[] idProducts)
        {
            List<Product> products = new List<Product>();
            for (int i = 0;i < idProducts.Length;i++)
            {
                products.Add(DbContext.Products.FirstOrDefault(p => p.ProductId == idProducts[i]));
            }
            return products;
        }
    }
}

