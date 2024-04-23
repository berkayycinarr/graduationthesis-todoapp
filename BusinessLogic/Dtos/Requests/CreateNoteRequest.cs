using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Dtos.Requests
{
    public class CreateNoteRequest : Note
    {
        public string Baslik { get; set; }
        public string? Icerik { get; set; }
        public int? Oncelik { get; set; }
    }
}
