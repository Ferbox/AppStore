using System.Collections.Generic;

namespace identity1.Domain.Entities
{
    public class Color
    {
        public Color()
        {
            Characteristics = new HashSet<Characteristics>();
        }
        public int ColorId { get; set; }
        public string Name { get; set; }
        public ICollection<Characteristics> Characteristics { get; set; }
    }
}
