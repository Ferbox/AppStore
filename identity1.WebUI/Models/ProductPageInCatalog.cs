using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace identity1.WebUI.Models
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
