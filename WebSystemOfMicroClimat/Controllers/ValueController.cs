using Microsoft.AspNetCore.Mvc;

namespace WebSystemOfMicroClimat.Controllers
{
    public class ValueController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
