using System.Collections.Generic;

namespace identity1.Common.Entities
{
    public class Member
    {
        public Member()
        {
            Products = new HashSet<Product>();
        }
        public int MemberId { get; set; }
        public int MemoryGB { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
