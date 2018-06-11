﻿using System.Collections.Generic;
using System.Linq;
using identity1.Domain.Entities;
using identity1.Domain.ViewModels;

namespace identity1.Domain.Abstract
{
    public interface IOrderRepository
    {
        void CreateOrder(Order order, string id, int[] orderlist, int[] qty);
        IEnumerable<OrderList> GetOrderList(int[] ProductidFromSession);
    }
}