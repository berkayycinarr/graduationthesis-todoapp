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
        List <CreatedNoteResponse> GetAllNotes();
        void AddNote(CreateNoteRequest createNoteRequest);
        void UpdateNote(CreateNoteRequest createNoteRequest);
        void DeleteNoteById(int id);
        public List <CreatedNoteResponse> GetNotesByDate(DateTime selectedDate);
        CreatedNoteResponse GetNotesById(int Id);
    }
}
