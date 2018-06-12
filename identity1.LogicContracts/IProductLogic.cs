using System.Collections.Generic;
using identity1.Common.Entities;

namespace identity1.LogicContracts
{
    public interface IProductLogic
    {
        Product GetProduct(int id);
        IEnumerable<Product> GetProducts(int type);
        IEnumerable<Product> GetProducts(int[] prodInBasket);
        void CreateOrder(Order order, string id, int[] orderlist, int[] qty);
    }
}
