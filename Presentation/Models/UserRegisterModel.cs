using Entities.Concrete;
using System.ComponentModel.DataAnnotations;

namespace Presentation.Models
{
    public class UserRegisterModel : User
    {
        public String FirstName { get; set; }
        [Required]
        public String LastName { get; set; }
        [Required]
        [EmailAddress]
        public String EmailAddress { get; set; }
        [Required]
        public String Password { get; set; }
        [Required]
        public String PhoneNumber { get; set; }
    }
}
