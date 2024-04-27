using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
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
        public bool IsActive { get; set; }
}
}
