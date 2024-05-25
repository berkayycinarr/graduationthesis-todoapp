using Entities.Concrete;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace APIService.Models
{
    public class UserLoginModel : User
    {
       
        [Required]
        [EmailAddress]
        public String emailAddress { get; set; }
        [Required]
        [PasswordPropertyText]
        public String password { get; set; }
    }
}
