using System.Collections.Generic;
using System.Linq;
using identity1.Domain.Abstract;
using identity1.Domain.Entities;
using identity1.Domain.ViewModels;
using Microsoft.AspNet.Identity;
namespace identity1.Domain.Concrete
{
    public class EFOrderRepository:IOrderRepository
    {
        ApplicationDbContext DbContext = new ApplicationDbContext();
        public void CreateOrder(Order order, string id)
        {
            order.UserId = id;
            //order.OrderItem.Add(new OrderItem{OrderId = order.OrderId , ProductId = });
            DbContext.Orders.Add(order);
            DbContext.SaveChanges();
            
        }

        public IEnumerable<OrderList> GetOrderList(int[] productidFromSession)
        {

            var ordlist = from p in DbContext.Products
                          join i in DbContext.Images on p.ProductId equals i.ProductId
                          where productidFromSession.Contains(p.ProductId) && (i.Name == "logo")
                          select new OrderList { ProductId = p.ProductId, Logo = i.Path, Title = p.Title, Cost = p.CostProduct };

            return ordlist;
        }
    }
}
