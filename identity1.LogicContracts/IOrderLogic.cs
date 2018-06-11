using System.Collections.Generic;
using identity1.Common.Entities;

namespace identity1.LogicContracts
{
    public interface IOrderLogic
    {
        void CreateOrder(Order order, string id, int[] orderlist, int[] qty);
        IEnumerable<Order> GetOrderList(int[] ProductidFromSession);
    }
}
