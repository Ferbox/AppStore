using System.Collections.Generic;

namespace identity1.Domain.Entities
{
    public class Display
    {
        public Display()
        {
            Characteristics = new HashSet<Characteristics>(); 
        }
        public int DisplayId { get; set; }
        public float Size { get; set; }
        public ICollection<Characteristics> Characteristics { get; set; }
    }
}
