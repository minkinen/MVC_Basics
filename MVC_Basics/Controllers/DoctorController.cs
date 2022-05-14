using Microsoft.AspNetCore.Mvc;
using MVC_Basics.Models;

namespace MVC_Basics.Controllers
{
    public class DoctorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult FeverCheck()
        {
            ViewBag.Message = DoctorModel.WriteMessage();
            return View();
        }

        [HttpPost]
        public IActionResult FeverCheck(string temperature)
        {
            ViewBag.Message = DoctorModel.FeverCheck(temperature);
            return View();
        }

    }
}
