﻿namespace identity1.Models
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
            this.Orders = new HashSet<Order>();
        }

        public int ProductId { get; set; }
        public string Title { get; set; }
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [DataType(DataType.Currency)]
        public int CountInStock { get; set; }
        public decimal CostProduct { get; set; }
        public int TypeId { get; set; }
        public ICollection<Feedback> Feedback { get; set; }
        public ICollection<Image> Images { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}