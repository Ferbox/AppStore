using System.Linq;
using System.Collections.Generic;
using identity1.Common.Entities;
using identity1.DALContracts;
using identity1.Common.EF;

namespace identity1.DAL.DAO
{
    public class ProductsDao:IProductDao
    {

        private ApplicationDbContext DbContext = new ApplicationDbContext();

        public IEnumerable<Product> GetProducts(int id)
        {
            return DbContext.Products.Where(x => x.ProductId == id);
        }

        public Product GetProduct(int id)
        {
            var product = DbContext.Products.FirstOrDefault(x => x.ProductId == id);
            IEnumerable<Image> images = DbContext.Images.Where(x => x.ProductId == product.ProductId);
            foreach (var item in images)
            {
                product.Images.Add(item);
            }
            return product;
        }
    }
}

