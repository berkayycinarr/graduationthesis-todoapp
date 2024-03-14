using BusinessLogic.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NoteController : Controller
    {
        private INoteDal _noteDal;

        [HttpPost("create/")]
        public IActionResult Create([FromBody] Note note)
        {
            if (note == null)
            {
                return BadRequest("Note object is null");
            }

            try
            {
                _noteDal.AddNote(note);
                return Ok("Note added successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("delete/{noteId}")]
        public IActionResult Delete(int noteId)
        {
            try
            {
                using (DataContext context = new DataContext())
                {
                    var note = context.Notes.FirstOrDefault(n => n.Id == noteId);
                    if (note != null)
                    {
                        context.Notes.Remove(note);
                        context.SaveChanges();
                        return Ok("Note deleted successfully");
                    }
                    else
                    {
                        return NotFound("Note not found");
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }



        [HttpPut("update/{noteId}")]
        public IActionResult Update(int noteId, [FromBody] Note updatedNote)
        {
            if (updatedNote == null)
            {
                return BadRequest("Updated note object is null");
            }

            try
            {
                var existingNote = _noteDal.GetNotesById(noteId);
                if (existingNote == null)
                {
                    return NotFound("Note not found");
                }

                existingNote.Baslik = updatedNote.Baslik;
                existingNote.Icerik = updatedNote.Icerik;
                existingNote.Yapildimi = updatedNote.Yapildimi;
                existingNote.NotTarihi = updatedNote.NotTarihi;
                existingNote.Saat = updatedNote.Saat;

                _noteDal.UpdateNote(existingNote);

                return Ok("Note updated successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("get/{noteId}")]
        public ActionResult<Note> GetById(int noteId)
        {
            try
            {
                var note = _noteDal.GetNotesById(noteId);

                if (note == null)
                {
                    return NotFound($"Note with ID {noteId} not found.");
                }

                return Ok(note);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("increase-priority/{noteId}")]
        public async Task<IActionResult> IncreasePriority(int id)
        {
            using (var context = new DataContext())
            {
                var note = await context.Notes.FindAsync(id);

                if (note == null)
                {
                    return NotFound();
                }

                note.Oncelik++;
                await context.SaveChangesAsync();

                return NoContent();
            }
        }

        [HttpGet("open-note/{noteid}")]
        public IActionResult OpenNote(int id)
        {
            var note = _noteDal.GetNotesById(id);
            if (note == null)
            {
                return NotFound();
            }
            return Ok(note);
        }















        //not arama
        
    }
 }
