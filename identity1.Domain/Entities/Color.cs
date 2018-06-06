using System.Collections.Generic;

namespace identity1.Domain.Entities
{
    public class Color
    {
        public Color()
        {
            Products = new HashSet<Product>();
        }
        public int ColorId { get; set; }
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
