using System.Collections.Generic;

namespace identity1.Domain.Entities
{
    public class SizeBody
    {
        public SizeBody()
        {
            Characteristics = new HashSet<Characteristics>();
        }
        public int SizeBodyId { get; set; }
        public int Size { get; set; }
        public ICollection<Characteristics> Characteristics { get; set; }
    }
}
