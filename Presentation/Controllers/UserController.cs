using BusinessLogic.Abstract;
using BusinessLogic.Concrete;
using DataAccess.Concrete.EntityFramework.Contexts;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using DataAccess.Concrete;
using Presentation.Models;
using Microsoft.Extensions.Logging;

namespace Presentation.Controllers
{
    public class UserController : Controller
    {
        private IUserService _userManager;

        public UserController(IUserService userManager)
        {
            _userManager = userManager;
        }

        public ActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                 _userManager.AddUser(user);
                return View("Login"); // Başarılı ekleme sonrasında giriş sayfasında yönlendir
            }

            return View("Register"); // Eğer model geçersizse kullanıcıyı aynı sayfada tut
        }

        public ActionResult Login(string email, string Password)
        {
            if (ModelState.IsValid)
            {

                var loggedUser = _userManager.GetByMail(email);
                if (loggedUser != null) 
                {

                    // Başarılı giriş sonrasında ana sayfaya yönlendir
                    return View("~/Views/Home/MainPage.cshtml");
                }
            }
            return View("Login"); // Geçersiz model ise, kullanıcıyı aynı sayfada tut
        }
        
        public async Task<ActionResult> GetByEmail(string email)
        {
            var user = _userManager.GetByMail(email);  
            if (user != null)
            {
                return View(user); // Kullanıcı bulunduysa detaylarını gösteren bir view döndür
            }
            else
            {
                return View("Anasayfa"); // Kullanıcı bulunamadıysa anasayfayı döndür
            }
        }



    }
}
