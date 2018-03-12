using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kondrat.PracticeTask.Travel.Data.Entities
{
    public class Photo
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(255)]
        public string Description { get; set; }

        [MaxLength(255)]
        public string Address { get; set; }

        [ForeignKey("Comment")]
        public int? CommentId { get; set; }

        [ForeignKey("User")]
        public int? UserId { get; set; }

        public virtual Comment Comment { get; set; }

        public virtual User User { get; set; }



    }
}