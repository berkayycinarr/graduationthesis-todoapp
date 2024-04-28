using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult HomePage()
        {
            return View("Anasayfa");
        }

        public IActionResult Giriş()
        {
            return View("~/Views/User/SignIn.cshtml");
        }

        public IActionResult KayıtOl()
        {
            return View("~/Views/User/SignUp.cshtml");
        }

    }
}
