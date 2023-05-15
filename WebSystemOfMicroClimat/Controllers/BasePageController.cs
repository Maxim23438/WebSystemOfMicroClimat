using Microsoft.AspNetCore.Mvc;

namespace WebSystemOfMicroClimat.Controllers
{
    public class BasePageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
