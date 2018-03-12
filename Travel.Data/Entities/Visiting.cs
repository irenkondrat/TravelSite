using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kondrat.PracticeTask.Travel.Data.Entities
{
    public class Visiting
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        [ForeignKey("City")]
        public int CityId { get; set; }

        [Required(ErrorMessage = "Status is a required field for entity Visiting")]
        public byte Status { get; set; }

        public uint? Mark { get; set; }

        public DateTime? DateOfVisit { get; set; }

        public virtual City City { get; set; }

        public virtual User User { get; set; }
    }
}