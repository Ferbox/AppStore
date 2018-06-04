using System.Collections.Generic;

namespace identity1.Domain.Entities
{
    public class Characteristics
    {
        public Characteristics()
        {
            Products = new HashSet<Product>();            
        }
        public int CharacteristicsId { get; set; }
        public int? MemberId { get; set; }
        public int? ColorId { get; set; }
        public int? DisplayId { get; set; }
        public int? SizeBodyId { get; set; }
        public bool? Cellular { get; set; }
        public bool? TouchBar { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
