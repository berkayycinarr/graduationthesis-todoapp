using Entities.Concrete;

namespace Presentation.Models
{
    public class NoteViewModel : Note
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
