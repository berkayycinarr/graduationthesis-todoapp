using Entities.Concrete;
using System.ComponentModel.DataAnnotations;

namespace APIService.Models
{
    public class UserRegisterModel : User
    {

        [Required]
        public string firstName { get; set; }
        [Required]
        public string lastName { get; set; }
        [Required]
        [EmailAddress]
        public string emailAddress { get; set; }
        [Required]
        public string password { get; set; }
        [Required]
        public string phoneNumber { get; set; }
    }
}
