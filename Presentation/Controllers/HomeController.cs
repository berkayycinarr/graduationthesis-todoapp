using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult HomePage()
        {
            return View("MainPage");
        }

        public IActionResult LoginButton()
        {
            return View("~/Views/User/Login.cshtml");
        }
        public IActionResult ProfileButton()
        {
            return View("~/Views/Account/Profile.cshtml");
        }

        public IActionResult RegisterButton()
        {
            return View("~/Views/User/Register.cshtml");
        }

        public IActionResult NotePageButton()
        {
            return View("~/Views/Note/NotePage.cshtml");
        }

        public IActionResult CalenderPageButton()
        {
            return View("~/Views/Calender/CalenderPage.cshtml");
        }



    }
}
