﻿namespace identity1.Models
{
    using System.Diagnostics.CodeAnalysis;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Feedback
    {
        [SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Feedback()
        {
            this.Image = new HashSet<Image>();
        }

        public int FeedbackId { get; set; }
        public string Text { get; set; }

        public int ProductId { get; set; }
        public string UserId { get; set; }
        public ICollection<Image> Image { get; set; }
    }
}
