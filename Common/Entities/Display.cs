using System.Collections.Generic;

namespace identity1.Common.Entities
{
    public class Display
    {
        public Display()
        {
            Products = new HashSet<Product>(); 
        }
        public int DisplayId { get; set; }
        public float Size { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
