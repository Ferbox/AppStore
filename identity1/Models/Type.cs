namespace identity1.Models
{
    using System.Diagnostics.CodeAnalysis;
    using System.Collections.Generic;

    public partial class Type
    {
        [SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Type()
        {
            this.Products = new HashSet<Product>();
        }

        public int TypeId { get; set; }
        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
