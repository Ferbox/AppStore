using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace identity1.Common.Entities
{
    public partial class ImageOfProduct
    {
        public ImageOfProduct()
        {
            Images = new HashSet<Image>();
        }
        public int ImageOfProductId { get; set; }
        public string Path { get; set; } = "/Content/Images/error.jpg";
        public ICollection<Image> Images { get; set; }
    }
}
