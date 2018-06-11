using System;
using System.Collections.Generic;
using identity1.Common.Entities;
using identity1.DALContracts;
using identity1.LogicContracts;

namespace identity1.Logic
{
    public class OrderLogic:IOrderLogic
    {
        private readonly IOrderDao orderDao;
        public OrderLogic(IOrderDao _orderDao)
        {
            orderDao = _orderDao;
        }

        public void CreateOrder(Order order, string id, int[] orderlist, int[] qty)
        {
            orderDao.CreateOrder(order, id, orderlist, qty);
        }

        IEnumerable<Order> IOrderLogic.GetOrderList(int[] ProductidFromSession) => throw new NotImplementedException();
    }
}
