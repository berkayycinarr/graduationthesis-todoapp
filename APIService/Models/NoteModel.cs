using APIService.Enums;
using Entities.Concrete;
using static APIService.Models.NoteModel;

namespace APIService.Models
{
    public class NoteModel : Note
    {
        public string baslik { get; set; }
        public string? icerik { get; set; }
        public bool? yapildimi { get; set; }
        public int? oncelik { get; set; } // Nullable enum kullanımı
        public DateTime notTarihi { get; set; }

    }
}
