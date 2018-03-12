using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Travel.Data.Entities
{
    public class UserCredentials
    {
        [Key]
        [ForeignKey("User")]
        public int Id { get; set; }

        [MaxLength(50), Required(ErrorMessage = "Email is a required field for entity UserCredentials")]
        public string Email { get; set; }

        [MinLength(6, ErrorMessage = "Password size must be between 6 and 50 characters for entity UserCredentials"), 
         MaxLength(50), Required(ErrorMessage = "Password is a required field for entity UserCredentials")]
        public string Password { get; set; }

        public System.DateTime RegistrationDate { get; set; }

        [MaxLength(50), Required(ErrorMessage = "Role is a required field for entity UserCredentials")]
        [RegularExpression("^Admin$|^User$", ErrorMessage = "Role can take only 'Admin' or 'User' values for entity User")]
        public string Role {get;set;}

        public virtual User User { get; set; }


    }
}