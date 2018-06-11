using System.Collections.Generic;
using identity1.Common.Entities;

namespace identity1.DALContracts
{
    public interface IProductDao
    {
        IEnumerable<Product> GetProducts(int id);
        Product GetProduct(int id);
    }
}
