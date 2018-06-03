namespace identity1.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            this.OrderItem = new HashSet<OrderItem>();
        }

        public int OrderId { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public DateTime UpdateDate { get; set; } = DateTime.Now;
        public string UserId { get; set; }
        public int StatusId { get; set; } = 1;
        public string DeliveryAddress { get; set; }
        public ICollection<OrderItem> OrderItem { get; set; }
    }
}
