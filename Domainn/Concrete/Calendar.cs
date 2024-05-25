using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Calendar
    {
        public int GunSayisi { get; set; }
        public int Saat { get; set; }
        public string Gun { get; set; }
        public Note Not { get; set; }
    }
}
