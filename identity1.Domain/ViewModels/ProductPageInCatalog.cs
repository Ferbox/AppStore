using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace identity1.Domain.ViewModels
{
    public class ProductPageInCatalog
    {
        [HiddenInput]
        public int ProductId { get; set; }
        public string Title { get; set; }
        [DataType(DataType.Currency)]
        public decimal CostProduct { get; set; }
        public int CountInStock { get; set; }
        public string Logo { get; set; }

    }
}
