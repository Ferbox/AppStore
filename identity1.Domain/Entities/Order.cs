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
            this.Products = new HashSet<Product>();
        }

        public int OrderId { get; set; }
        public DateTime Date { get; set; }
        public DateTime UpdateDate { get; set; }
        public int Count { get; set; }
        public string UserId { get; set; }
        public int StatusId { get; set; } = 1;
        public string DeliveryAddress { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
