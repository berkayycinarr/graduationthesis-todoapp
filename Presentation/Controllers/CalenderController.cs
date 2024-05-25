using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    public class CalenderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
