using System.Linq;
using System.Collections.Generic;
using identity1.Common.Entities;
using identity1.DALContracts;
using identity1.Common.EF;
using System.Data.Entity;
using identity1.Common.Models.ViewModels;

namespace identity1.DAL.DAO
{
    public class ProductsDao:IProductDao
    {
        private ApplicationDbContext DbContext = new ApplicationDbContext();
        public ProductPage GetProduct(int id)
        {


            var product = DbContext.Products.FirstOrDefault(x => x.ProductId == id);
            ProductPage productPage = new ProductPage { ProductId = product.ProductId, TypeId = product.TypeId, Cost = product.CostProduct, Count = product.CountInStock, Description = product.Description, Title = product.Title };
            var images = ( from i in DbContext.ImagesProd
                           join i_p in DbContext.ImageProduct on i.ImageOfProductId equals i_p.ImageOfProductId
                           where i_p.ProductId == id
                           select i).ToList();
            productPage.Images = new List<ImageOfProduct>();
            productPage.Images.AddRange(images);

            return productPage;
        }
        public IEnumerable<ProdCatalogViewModel> GetProducts(int type)
        {
            //var pr = DbContext.Products.Include(x => x.Images).GroupBy(p => p.Title).Select(y => y.FirstOrDefault());
            var products = from p in DbContext.Products
                           join ip in DbContext.ImageProduct on p.ProductId equals ip.ProductId
                           join i in DbContext.ImagesProd on ip.ImageOfProductId equals i.ImageOfProductId
                           where p.TypeId == type
                           select new ProdCatalogViewModel { ProductId = p.ProductId, Title = p.Title, Cost = p.CostProduct, Count = p.CountInStock, Logo = i.Path };
            return products.GroupBy(x => x.Title).Select(t => t.FirstOrDefault());
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

        public void CreateProduct(Product product, List<string> nameFiles)
        {
            List<Image> listImage = new List<Image>();
            DbContext.Products.Add(product);
            foreach (var item in nameFiles)
            {
                ImageOfProduct image = new ImageOfProduct { Path = item };
                DbContext.ImageProduct.Add(new Image { ProductId = product.ProductId, ImageOfProductId = image.ImageOfProductId });
                DbContext.ImagesProd.Add(image);
            }
            DbContext.SaveChanges();
        }
    }
}

