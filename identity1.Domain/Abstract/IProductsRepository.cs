using System.Collections.Generic;
using identity1.Domain.Entities;
using identity1.Domain.ViewModels;

namespace identity1.Domain.Abstract
{
    public interface IProductsRepository
    {

        IEnumerable<ProductPageInCatalog> GetProductsForCatalog(int type);
        ProductPage GetProduct(int id);
        
    }
}
