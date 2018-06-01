using System.ComponentModel.DataAnnotations;

namespace identity1.Domain.Entities
{
    public class OrderDetails
    {
        [Required(ErrorMessage = "Вставьте первый адрес доставки")]
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Line3 { get; set; }

        [Required(ErrorMessage = "Укажите город")]
        public string City { get; set; }
    }
}
