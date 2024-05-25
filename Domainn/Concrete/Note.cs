using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Note
    {
        [Key]
        public int Id { get; set; }
        public string baslik { get; set; }
        public string? icerik { get; set; }
        public bool? yapildimi { get; set; }
        public DateTime notTarihi { get; set; }
        public int? oncelik { get; set; }

    }
}
