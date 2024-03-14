using BusinessLogic.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Concrete
{
    public class NoteManager : INoteService
    {
        private INoteDal _noteDal;

        public NoteManager(INoteDal noteDal)
        {
            _noteDal = noteDal;
        }

        public void AddNote(Note note)
        {
            _noteDal.AddNote(note);
        }

        public void DeleteNoteById(int id)
        {
            _noteDal.DeleteNoteById(id);
        }

        public List<Note> GetAllNotes()
        {
            return _noteDal.GetAllNotes();
        }

        public void UpdateNote(Note note)
        {
            _noteDal.UpdateNote(note);
        }

        public List<Note> GetNotesByDate(DateTime selectedDate)
        {
            return _noteDal.GetNotesByDate(selectedDate);
        }

        public Note GetNotesById(int Id)
        {
            return _noteDal.GetNotesById(Id);
        }
    }
}
