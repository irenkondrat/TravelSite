using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kondrat.PracticeTask.Travel.Data.Entities
{
   public class Comment
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("City")]
        public int CityId { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        [MaxLength(255)]
        public string Text { get; set; }

        public DateTime? LastModifiedDate { get; set; }

        public int? AdminId { get; set; }

        public virtual City City { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<Photo> Photos { get; set; }

    }
}
