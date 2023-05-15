using Microsoft.AspNetCore.Mvc;
using WebSystemOfMicroClimat.Models;

namespace WebSystemOfMicroClimat.Controllers
{
    public class LightController : Controller
    {
        public IActionResult Light(int userId)
        {
            userId = (int)TempData["userId"];
            Console.WriteLine($"{userId}");
            TempData["userId"] = userId;
            return View();
        }
    }
}
