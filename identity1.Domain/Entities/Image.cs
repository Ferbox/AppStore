namespace identity1.Domain.Entities
{
    public partial class Image
    {
        public int ImageId { get; set; }
        public string Name { get; set; }
        public string Path { get; set; } = "/Content/Images/error.jpg";
        public int? ProductId { get; set; }
        public int? FeedbackId { get; set; }
    }
}
