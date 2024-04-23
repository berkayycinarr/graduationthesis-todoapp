using BusinessLogic.Abstract;
using BusinessLogic.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Presentation.Models;

namespace Presentation.Controllers
{
    public class NoteController : Controller
    {
        private NoteManager _noteManager;
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddNote(Note note)
        {
            if (ModelState.IsValid)
            {
                _noteManager.AddNote(note);
                return RedirectToAction("Index"); // Eğer başarılıysa ana sayfaya yönlendir
            }
            return View(note); // Eğer geçersiz veri varsa tekrar aynı sayfayı göster
        }

        public IActionResult GetAllNotes()
        {
            return Ok(_noteManager.GetAllNotes);
        }
    }
}
