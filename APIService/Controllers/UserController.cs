using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace APIService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private IUserDal _userDal;

        [HttpPost("create/")]
        public IActionResult Create([FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest("User did not find");
            }

            try
            {
                _userDal.Add(user);
                return Ok("User added successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("update/{id}")]
        public IActionResult Update(int id, [FromBody] User updatedUser)
        {
            try
            {
                var existingUser = _userDal.GetUserById(id); // Kullanıcıyı id'ye göre al
                if (existingUser == null)
                {
                    return NotFound();
                }

                existingUser.FirstName = updatedUser.FirstName;
                existingUser.LastName = updatedUser.LastName;
                existingUser.EmailAddress = updatedUser.EmailAddress;
                existingUser.Password = updatedUser.Password;
                existingUser.PhoneNumber = updatedUser.PhoneNumber;

                _userDal.Update(existingUser);

                return Ok();
            }

            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }




        
    }
}

