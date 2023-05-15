using Microsoft.AspNetCore.Mvc;
using WebSystemOfMicroClimat.Models;

namespace WebSystemOfMicroClimat.Controllers
{
    public class HumidityController : Controller
    {
        public IActionResult Humidity(int userId)
        {
            userId = (int)TempData["userId"];
            Console.WriteLine($"{userId}");
            TempData["userId"] = userId;
            return View();
        }
    }
}
