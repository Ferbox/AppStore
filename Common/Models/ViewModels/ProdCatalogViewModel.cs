namespace identity1.Common.Models.ViewModels
{
    public class ProdCatalogViewModel
    {
        public int ProductId { get; set; }
        public string Title { get; set; }
        public string Logo { get; set; }
        public decimal MinCost { get; set; }
        public decimal MaxCost { get; set; }
    }
}
