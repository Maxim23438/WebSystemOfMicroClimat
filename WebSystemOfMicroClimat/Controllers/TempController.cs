using Microsoft.AspNetCore.Mvc;

namespace WebSystemOfMicroClimat.Controllers
{
    public class TempController : Controller
    {
        public IActionResult Temp(int userId)
        {
            userId = (int)TempData["userId"];
            Console.WriteLine($"{userId}");
            TempData["userId"] = userId;
            return View();
        }
    }
}
