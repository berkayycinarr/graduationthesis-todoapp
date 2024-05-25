using APIService.Models;
using BusinessLogic.Abstract;
using BusinessLogic.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private IUserDal _userDal;
        private IUserService _userManager;
        private readonly ILogger<UserController> _logger;
        public UserController (IUserService userManager, IUserDal userDal)
        {
            _userManager = userManager;
            _userDal = userDal;
        }


        [HttpPost("create/")]
        public async Task<IActionResult> Create([FromBody] UserRegisterModel model)
        {       
            
                if (model == null)
                {
                    return BadRequest("User did not find");
                }

                try
                {
                   var user = new User
                   {
                    firstName = model.firstName,
                    lastName = model.lastName,
                    emailAddress = model.emailAddress,
                    phoneNumber = model.phoneNumber,
                    password = model.password,
                    isActive = true
                   };
                _userManager.AddUser(user);
                    return Ok("User başarıyla eklendi");
                }
                catch (DbUpdateException ex)
                {
                    // Log the detailed error message
                    var innerExceptionMessage = ex.InnerException?.Message;
                    return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {innerExceptionMessage}");
                }
         }
        

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] UserLoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid login attempt.");
            }

            var user = await _userManager.GetByMail(model.emailAddress);
            if (user == null)
            {
                return NotFound("User not found. Please first do Register");
            }

            if (user.emailAddress != model.emailAddress & user.password != model.password)
            {
                // Kullanıcı email adresi veya şifre hatalı.
                // Burada gerekli işlemler yapılabilir.
                return BadRequest("Invalid login attempt.");
            }

            else
            {
                // Kullanıcı giriş başarılı, burada gerekli işlemler yapılacak.
                user.isActive = true;
                _userManager.LogIn(user);
                return Ok("Login successful.");
            }
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Edit (int id, [FromBody] UserRegisterModel model)
        {
            try
            {
                var existingUser = _userDal.GetUserById(id); // Kullanıcıyı id'ye göre al
                if (existingUser == null)
                {
                    return NotFound();
                }

                existingUser.firstName = model.firstName;
                existingUser.lastName = model.lastName;
                existingUser.emailAddress = model.emailAddress;
                existingUser.password = model.password;
                existingUser.phoneNumber = model.phoneNumber;

                _userDal.Update(existingUser);

                return Ok();
            }

            catch (DbUpdateException ex)
            {
                // Log the detailed error message
                var innerExceptionMessage = ex.InnerException?.Message;
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {innerExceptionMessage}");
            }
        }




        
    }
}

