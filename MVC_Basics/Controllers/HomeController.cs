using Microsoft.AspNetCore.Mvc;

namespace MVC_Basics.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
