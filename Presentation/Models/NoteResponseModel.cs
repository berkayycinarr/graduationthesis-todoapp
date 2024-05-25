using Entities.Concrete;

namespace Presentation.Models
{
    public class NoteResponseModel : Note
    {
        public string Baslik { get; set; }
        public string? Icerik { get; set; }
        public int? Oncelik { get; set; }

    }
}
