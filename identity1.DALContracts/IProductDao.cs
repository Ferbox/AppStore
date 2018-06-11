using System.Collections.Generic;
using identity1.Common.Entities;

namespace identity1.DALContracts
{
    public interface IProductDao
    {
        IEnumerable<Product> GetProductsForCatalog(int type);
        Product GetProduct(int id);
        IEnumerable<Product> GetProductsForCart(int[] idProducts);

    }
}
