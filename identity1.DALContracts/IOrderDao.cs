using System.Collections.Generic;
using identity1.Common.Entities;

namespace identity1.DALContracts
{
    public interface IOrderDao
    {
        void CreateOrder(Order order, string id, int[] orderlist, int[] qty);
        IEnumerable<Product> GetOrderList(int[] ProductidFromSession);
    }
}
