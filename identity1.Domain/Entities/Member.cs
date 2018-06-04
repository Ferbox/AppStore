using System.Collections.Generic;

namespace identity1.Domain.Entities
{
    public class Member
    {
        public Member()
        {
            Characteristics = new HashSet<Characteristics>();
        }
        public int MemberId { get; set; }
        public int MemoryGB { get; set; }
        public ICollection<Characteristics> Characteristics { get; set; }
    }
}
