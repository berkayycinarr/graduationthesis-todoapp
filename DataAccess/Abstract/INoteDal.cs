using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface INoteDal
    {
        void AddNote(Note note);
        void UpdateNote(Note note);
        void DeleteNoteById(int id);
        List <Note> GetAllNotes(Func<Note, bool> filter = null);
        List <Note> GetNotesByDate(DateTime selectedDate);
        Note GetNotesById(int Id);
    }
}
