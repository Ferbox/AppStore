namespace identity1.Domain.Entities
{
    using System.Diagnostics.CodeAnalysis;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Product
    {
        [SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            this.Feedback = new HashSet<Feedback>();
            this.Images = new HashSet<Image>();
            this.OrderItem = new HashSet<OrderItem>();
        }
        public int ProductId { get; set; }
        public string Title { get; set; }
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        public int CountInStock { get; set; }
        [DataType(DataType.Currency)]
        public decimal CostProduct { get; set; }
        public int TypeId { get; set; }
        public int CharacteristicsId { get; set; }
        public ICollection<Feedback> Feedback { get; set; }
        public ICollection<Image> Images { get; set; }
        public ICollection<OrderItem> OrderItem { get; set; }
    }
}