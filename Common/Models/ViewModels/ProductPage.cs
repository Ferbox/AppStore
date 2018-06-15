using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using identity1.Common.Entities;


namespace identity1.Common.Models.ViewModels
{
    public class ProductPage
    {
        public int ProductId { get; set; }
        public string Title { get; set; }
        public string Decsription { get; set; }
        public List<ImageOfProduct> Images { get; set; }
        public decimal Cost { get; set; }
        public int Count { get; set; }

    }
}

