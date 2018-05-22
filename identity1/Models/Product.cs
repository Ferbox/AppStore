﻿namespace identity1.Models
{
    using System.Diagnostics.CodeAnalysis;
    using System.Collections.Generic;

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
        public string Description { get; set; }
        public int CountInStock { get; set; }
        public decimal CostProduct { get; set; }

        public int TypeId { get; set; }
        public  ICollection<Feedback> Feedback { get; set; }
        public ICollection<Image> Images { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}