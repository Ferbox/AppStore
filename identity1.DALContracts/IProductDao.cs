using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using identity1.Common.Entities;

namespace identity1.DALContracts
{
    public interface IProductDao
    {
        Task<Product> GetProduct(int id);
        IEnumerable<Product> GetProducts(int type);
        IEnumerable<Product> GetProducts(int[] idProducts);
        void CreateOrder(Order order, string id, int[] orderlist, int[] qty);
    }
}
