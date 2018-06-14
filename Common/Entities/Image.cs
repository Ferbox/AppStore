using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace identity1.Common.Entities
{
    public class Image
    {
        [Key, Column(Order = 1)]
        public int ImageOfProductId { get; set; }
        [Key, Column(Order = 2)]
        public int ProductId { get; set; }
    }
}
