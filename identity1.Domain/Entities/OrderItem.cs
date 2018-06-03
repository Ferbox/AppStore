using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace identity1.Domain.Entities
{
    public class OrderItem
    {
        [Key, Column(Order = 1)]
        public int OrderId { get; set; }
        [Key, Column(Order = 2)]
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        
    }
}
