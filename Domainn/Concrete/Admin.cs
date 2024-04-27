using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Admin
    {
        public int Id { get; set; }
        public int UserId { get; set;}
        public String Password { get; set; }
        public bool Status { get; set; }
    }
}
