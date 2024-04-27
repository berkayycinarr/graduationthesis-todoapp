using BusinessLogic.Abstract;
using BusinessLogic.Concrete;
using DataAccess.Concrete.EntityFramework.Contexts;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using DataAccess.Concrete;
using Presentation.Models;

namespace Presentation.Controllers
{
    public class UserController : Controller
    {
        private IUserService _userManager;

        public UserController(IUserService userManager)
        {
            _userManager = userManager;
        }

        public ActionResult SignUp(User user)
        {
            if (ModelState.IsValid)
            {
                 _userManager.AddUser(user);
                return View("SignIn"); // Başarılı ekleme sonrasında giriş sayfasında yönlendir
            }
            return View(user); // Eğer model geçersizse kullanıcıyı aynı sayfada tut
        }

        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _userManager.GetByMail(model.EmailAddress);
                if (user != null)
                {
                    // Kullanıcı giriş yaptı, statusunu true yap
                    
                    //user.IsActive = true;
                    //_userManager.UpdateUser(user);

                    // Başarılı giriş sonrasında ana sayfaya yönlendir
                    return View("Anasayfa");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid email or password.");
                }
            }
            return View(model); // Geçersiz model ise, kullanıcıyı aynı sayfada tut ve hata mesajı göster
        }


        public async Task<ActionResult> GetByEmail(string email)
        {
            var user = await _userManager.GetByMail(email);
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
