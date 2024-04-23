using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace APIService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalendarController : ControllerBase
    {
        private INoteDal _noteDal;

        [HttpPost]
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
    }
}
