using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Note
    {
        public int Id { get; set; }
        public string Baslik { get; set; }
        public string? Icerik { get; set; }
        public bool? Yapildimi { get; set; }
        public DateTime NotTarihi { get; set; }
        public TimeOnly Saat { get; set; }
        public int? Oncelik { get; set; }

    }
}
