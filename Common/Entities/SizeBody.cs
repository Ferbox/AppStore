using System.Collections.Generic;

namespace identity1.Common.Entities
{
    public class SizeBody
    {
        public SizeBody()
        {
            Products = new HashSet<Product>();
        }
        public int SizeBodyId { get; set; }
        public int Size { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
