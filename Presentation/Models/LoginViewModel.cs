using Entities.Concrete;
using System.ComponentModel.DataAnnotations;

namespace Presentation.Models
{
    public class LoginViewModel : User
    { 
        public string EmailAddress { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
