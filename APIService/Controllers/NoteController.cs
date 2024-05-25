using APIService.Models;
using BusinessLogic.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        private INoteDal _noteDal;
        private INoteService _noteManager;

        public NoteController(INoteService noteManager, INoteDal noteDal)
        {
            _noteManager = noteManager;
            _noteDal =  noteDal;
        }

        [HttpPost("create/")]
        public async Task<IActionResult> Create([FromBody] NoteModel model)
        {
            if (model == null)
            {
                return BadRequest("Note object is null");
            }

            try
            {
                var note = new NoteModel
                {
                    baslik = model.baslik,
                    icerik = model.icerik,
                    yapildimi = model.yapildimi,
                    oncelik = model.oncelik,
                    notTarihi = DateTime.UtcNow,
                    
                };
                _noteManager.AddNote(note);
                return Ok("Note added successfully");
            }
            catch (DbUpdateException ex)
            {
                // Log the detailed error message
                var innerExceptionMessage = ex.InnerException?.Message;
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {innerExceptionMessage}");
            }
        }

        [HttpDelete("delete/{noteId}")]
        public async Task <IActionResult> Delete(int noteId)
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
            catch (DbUpdateException ex)
            {
                // Log the detailed error message
                var innerExceptionMessage = ex.InnerException?.Message;
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {innerExceptionMessage}");
            }
        }



        [HttpPut("update/{noteId}")]
        public async Task<IActionResult> Update(int noteId, [FromBody] Note updatedNote)
        {
            if (updatedNote == null)
            {
                return BadRequest("Updated note object is null");
            }

            try
            {
                var existingNote = await _noteManager.GetNotesById(noteId);
                if (existingNote == null)
                {
                    return NotFound("Note not found");
                }

                existingNote.baslik = updatedNote.baslik;
                existingNote.icerik = updatedNote.icerik;
                existingNote.yapildimi = updatedNote.yapildimi;
                existingNote.oncelik = updatedNote.oncelik;

                _noteManager.UpdateNote(existingNote);

                return Ok("Note updated successfully");
            }
            catch (DbUpdateException ex)
            {
                // Log the detailed error message
                var innerExceptionMessage = ex.InnerException?.Message;
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {innerExceptionMessage}");
            }
        }
        [HttpGet("get/{noteId}")]
        public async Task<ActionResult<Note>> GetById(int noteId)
        {
            try
            {
                var note = await _noteManager.GetNotesById(noteId);
                if (note == null)
                {
                    return NotFound($"Note with ID {noteId} not found.");
                }

                return Ok(note);
            }
            catch (DbUpdateException ex)
            {
                // Log the detailed error message
                var innerExceptionMessage = ex.InnerException?.Message;
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {innerExceptionMessage}");
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

                note.oncelik++;
                await context.SaveChangesAsync();

                return NoContent();
            }
        }

        [HttpGet("open-note/{noteid}")]
        public IActionResult OpenNote(int id)
        {
            var note = _noteManager.GetNotesById(id);
            if (note == null)
            {
                return NotFound();
            }
            return Ok(note);
        }















        //not arama
        
    }
 }
