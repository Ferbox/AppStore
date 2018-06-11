namespace identity1.WebUI.Models
{


    public class OrderList
    {
        public int ProductId { get; set; }
        public string Logo { get; set; }
        public string Title { get; set; }
        public decimal Cost { get; set; }
        public int Qty { get; set; } = 1;

    }
}
