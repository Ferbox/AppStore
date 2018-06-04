using System.Linq;
using System.Collections.Generic;
using identity1.Domain.Abstract;
using identity1.Domain.Entities;

using identity1.Domain.ViewModels;
namespace identity1.Domain.Concrete
{
    public class EFProductsRepository:IProductsRepository
    {
        enum SizeBodyWatch
        {
            _38mm = 1,
            _42mm = 2
        }
        enum MemberSize
        {
            _16gb = 1,
            _32gb = 2,
            _64gb = 3,
            _128gb = 4,
            _256gb = 5,
            _512gb = 6
        }
        enum Color
        {
            red = 1,
            spacegray = 2,
            silver = 3,
            rose = 4,
            rosegold = 5
        }
        ApplicationDbContext DbContext = new ApplicationDbContext();
        public IEnumerable<ProductPageInCatalog> GetProductsForCatalog(int type)
        {
            var productlist = from p in DbContext.Products
                              join i in DbContext.Images on p.ProductId equals i.ProductId
                              where p.TypeId == type && i.Name == "logo"
                              select new ProductPageInCatalog { ProductId = p.ProductId, CostProduct = p.CostProduct, CountInStock = p.CountInStock, Logo = i.Path, Title = p.Title };
            return productlist;
        }

        public ProductPage GetProduct(int id)
        {
            //var product = from p in DbContext.Products
            //              join i in DbContext.Images on p.ProductId equals i.ProductId
            //              join
            return null;
        }
    }
}

