namespace identity1.Common.Entities
{
    using System.Diagnostics.CodeAnalysis;
    using System.Collections.Generic;

    public partial class Feedback
    {
        [SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Feedback()
        {
            this.Images = new HashSet<ImageofFeedback>();
        }

        public int FeedbackId { get; set; }
        public string Text { get; set; }

        public int ProductId { get; set; }
        public string UserId { get; set; }
        public ICollection<ImageofFeedback> Images { get; set; }
    }
}
