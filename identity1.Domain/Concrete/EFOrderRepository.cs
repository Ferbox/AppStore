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
        public void CreateOrder(Order order, string id, int[] orderlist, int[] qty)
        {
            order.UserId = id;
            for (int i = 0;i < orderlist.Length;i++)
            {
                DbContext.OrderItem.Add(new OrderItem { OrderId = order.OrderId, ProductId = orderlist[i], Quantity = qty[i] });
            }
            DbContext.Orders.Add(order);
            DbContext.SaveChanges();
        }

        public IEnumerable<OrderList> GetOrderList(int[] productidFromSession)
        {
            var ordlist = from p in DbContext.Products
                          join i in DbContext.Images on p.ProductId equals i.ProductId
                          where productidFromSession.Contains(p.ProductId) && ( i.Name == "logo" )
                          select new OrderList { ProductId = p.ProductId, Logo = i.Path, Title = p.Title, Cost = p.CostProduct };
            for (int i = 0;i < productidFromSession.Length;i++)
            {
                foreach (var item in ordlist)
                {
                    if (productidFromSession[i] == item.ProductId)
                    {
                        yield return new OrderList { ProductId = item.ProductId, Logo = item.Logo, Title = item.Title, Cost = item.Cost };
                    }
                }
            }
        }
    }
}
