using System.ComponentModel.DataAnnotations;

namespace identity1.Common.Entities
{
    public class ImageofFeedback
    {
        public int ImageofFeedbackId { get; set; }
        public string Path { get; set; } = "/Content/Images/error.jpg";
        public int FeedbackId { get; set; }
    }
}
