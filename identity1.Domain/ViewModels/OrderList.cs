namespace identity1.Domain.ViewModels
{
    public class OrderList
    {
        public int ProductId { get; set; }
        public string PathToImage { get; set; }
        public string Title { get; set; }
        public decimal Cost { get; set; }
        public int Count { get; set; } = 1;

    }
}
