using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kondrat.PracticeTask.Travel.Data.Entities
{
    public class City
    {
        [Key]   
        public int Id { get; set; }

        [MaxLength(50),Required]
        public string Name { get; set; }

        [MaxLength(50), Required]
        public string Country { get; set; }

        [MaxLength(50), Required]
        public string Coordinates { get; set; }

        [NotMapped]
        public float AverageScore { get; set; }

        public virtual ICollection<Visiting> Visitings { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }



    }
}