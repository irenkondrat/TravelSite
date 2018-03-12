using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Travel.Data.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
 
        [MaxLength(50)]
        public string FirstName { get; set; }

        [MaxLength(50)]
        public string LastName { get; set; }

        [MaxLength(50)]
        public string NickName { get; set; }

        public DateTime? DateOfBirth { get; set; }

        [RegularExpression("^M$|^F$", ErrorMessage = "Gender can take only 'M' or 'F' values for entity User")]
        public char Gender { get; set; }

        [MaxLength(50)]
        public string Сountry { get; set; }

        public virtual ICollection<Photo> Photos { get; set; }

        public virtual ICollection<Visiting> Visitings { get; set; }

        public virtual ICollection<Comment> Comments{ get; set; }
    }
}