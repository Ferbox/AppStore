using identity1.Domain.Entities;

namespace identity1.Domain.Abstract
{
    public interface IOrderRepository
    {
         void CreateOrder(Order order);
    }
}
