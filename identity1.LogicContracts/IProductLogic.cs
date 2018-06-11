using System.Collections.Generic;
using identity1.Common.Entities;

namespace identity1.LogicContracts
{
    public interface IProductLogic
    {
        IEnumerable<Product> GetProductsForCatalog(int type);

        Product GetProduct(int id);

        IEnumerable<Product> GetProductForCart(int[] prodInBasket);
    }
}
