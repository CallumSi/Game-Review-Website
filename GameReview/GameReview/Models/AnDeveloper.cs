using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace GameReview.Models
{
    public class AnDeveloper
    {

        [Key]
        public virtual int DeveloperId { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual int GameId { get; set; }
        public virtual List<AnGame> GamesDeveloped { get; set; }
        public virtual int CommentId { get; set; }
        public virtual ICollection<AnComment> ListComment { get; set; }
    }
}