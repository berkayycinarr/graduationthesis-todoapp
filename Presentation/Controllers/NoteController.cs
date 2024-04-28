using BusinessLogic.Abstract;
using BusinessLogic.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Presentation.Models;
using static Azure.Core.HttpHeader;

namespace Presentation.Controllers
{
    public class NoteController : Controller
    {
        private INoteService _noteManager;
        private DataContext _context;

        public NoteController(INoteService noteManager)
        {
            _noteManager = noteManager;
        }
        
        [HttpPost]
        public ActionResult AddNote(Note note)
        {
            if (ModelState.IsValid)
            {
                _noteManager.AddNote(note);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Edit(Note note)
        {
            if (ModelState.IsValid)
            {
                var existingNote = _context.Notes.FirstOrDefault(n => n.Id == note.Id);

                if (existingNote != null)
                {
                    existingNote.Baslik = note.Baslik;
                    existingNote.Icerik = note.Icerik;
                    existingNote.Yapildimi = note.Yapildimi;
                    existingNote.Oncelik = note.Oncelik;
                }
                return RedirectToAction("Index");
            }
            return View(note);
        }

        public ActionResult Delete(int id)
        {
            var note = _context.Notes.FirstOrDefault(n => n.Id == id);
            if (note != null)
            {
                _noteManager.DeleteNoteById(id);
            }
            return RedirectToAction("Index");
        }

        

        public IActionResult GetAllNotes()
        {
            return Ok(_noteManager.GetAllNotes);
        }



    }
}
