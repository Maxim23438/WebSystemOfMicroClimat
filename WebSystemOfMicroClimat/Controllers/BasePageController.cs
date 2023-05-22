using Microsoft.AspNetCore.Mvc;

namespace WebSystemOfMicroClimat.Controllers
{
    public class BasePageController : Controller
    {
        public IActionResult Index()
        {
            TempData["userId"] = 0;
            return View();
        }
        public IActionResult Dovidka()
        {
            TempData["userId"] = 0;
            return View();
        }
    }
}
