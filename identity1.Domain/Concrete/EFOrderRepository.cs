using identity1.Domain.Abstract;
using identity1.Domain.Entities;

namespace identity1.Domain.Concrete
{
    public class EFOrderRepository:IOrderRepository
    {
        ApplicationDbContext DbContext = new ApplicationDbContext();
        public void CreateOrder(Order order)
        {
            DbContext.Orders.Add(order);
            DbContext.SaveChanges();
        }

    }
}
