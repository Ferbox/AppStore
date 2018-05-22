namespace identity1.Models
{
    using System.Diagnostics.CodeAnalysis;
    using System.Collections.Generic;

    public partial class Status
    {
        [SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Status()
        {
            this.Orders = new HashSet<Order>();
        }

        public int StatusId { get; set; }
        public string Name { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
