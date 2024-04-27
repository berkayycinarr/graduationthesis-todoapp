using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

       
        /*public ActionResult Login(Admin admin)
        {
            if (ModelState.IsValid)
            {
                // Burada gerçek bir kimlik doğrulama işlemi gerçekleştirilmelidir
                // Örneğin, modeldeki kullanıcı adı ve şifre veritabanındaki bir kayıtla eşleşiyorsa giriş başarılıdır.
                // Bu örnekte basitçe her girişi başarılı sayalım ve yönlendirme yapalım.
                Session["AdminUsername"] = model.Username;
                return RedirectToAction("Index", "Note");
            }
            return View(Index);
        }

        // Sistemden çıkış yapma işlemi
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }
        */
    }
}
