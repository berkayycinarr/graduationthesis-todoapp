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

        public ActionResult SignUp(User user)
        {
            if (ModelState.IsValid)
            {
                 _userManager.AddUser(user);
                return View("SignIn"); // Başarılı ekleme sonrasında giriş sayfasında yönlendir
            }
            return View(user); // Eğer model geçersizse kullanıcıyı aynı sayfada tut
        }

        public async Task<ActionResult> SignIn(LoginViewModel usermodel)
        {
            if (ModelState.IsValid)
            {
                var loggedUser = _userManager.GetByMail(usermodel.EmailAddress);
                if (loggedUser != null)
                {
                    _userManager.LogIn(loggedUser);// Kullanıcı giriş yaptı
                    _userManager.UpdateUserStatus(loggedUser.Id,true);//status güncellendi
                   
                    // Başarılı giriş sonrasında ana sayfaya yönlendir
                    return RedirectToAction("Anasayfa");
                }
            }
            return View("SignIn"); // Geçersiz model ise, kullanıcıyı error sayfasına at
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
