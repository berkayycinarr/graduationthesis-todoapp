using BusinessLogic.Dtos.Requests;
using BusinessLogic.Dtos.Responses;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract
{
    public interface INoteService
    {
        List <Note> GetAllNotes();
        void AddNote(Note note);
        void UpdateNote(Note note);
        void DeleteNoteById(int id);
        List <Note> GetNotesByDate(DateTime selectedDate);
        Note GetNotesById(int Id);
    }
}
