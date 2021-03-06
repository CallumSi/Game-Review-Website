using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameReview.Models
{
    public class AnReview
    {
        [Key]
        public virtual int ReviewId { get; set; }
        [Required]
        public virtual string ReviewText { get; set; }
        [Range(1,10)]
        [Required]
        public virtual int ReviewScore { get; set; }
        public virtual int UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual AnUser AnUser { get; set; }
        public virtual List<AnReviewReply> ReviewReplies { get; set; }
    }
}