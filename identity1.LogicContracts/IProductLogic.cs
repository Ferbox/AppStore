using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using identity1.Common.Entities;
using identity1.Common.Models.ViewModels;

namespace identity1.LogicContracts
{
    public interface IProductLogic
    {
        ProductPage GetProduct(int id);
        IEnumerable<ProdCatalogViewModel> GetProducts(int type);
        IEnumerable<Product> GetProducts(int[] prodInBasket);
        void CreateOrder(Order order, string id, int[] orderlist, int[] qty);
        void CreateProduct(Product product, string[] charak, List<string> nameFiles);
    }
}
