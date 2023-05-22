using Microsoft.AspNetCore.Mvc;
using WebSystemOfMicroClimat.Data.Services;
using WebSystemOfMicroClimat.Models;

namespace WebSystemOfMicroClimat.Controllers
{
    public class TempController : Controller
    {
        private readonly ITempService _service;
        public TempController(ITempService service)
        {
            _service = service;
        }
        public IActionResult Temp(int userId)
        {
            userId = (int)TempData["userId"];
            Console.WriteLine($"{userId}");
            TempData["userId"] = userId;
            var temp = _service.GetById(userId);
            if(temp != null )
            {
                ViewBag.Battery = temp.Battery;
                ViewBag.Kotel = temp.Kotel;
                ViewBag.Kamin = temp.Kamin;
                ViewBag.Obigriv = temp.Obigriv;
                ViewBag.Lamp = temp.Lamp;
                ViewBag.Bottom = temp.Bottom;
                ViewBag.Cond = temp.Cond;
            }
            else
            {
                ViewBag.Battery = false;
                ViewBag.Kotel = false;
                ViewBag.Kamin = false;
                ViewBag.Obigriv = false;
                ViewBag.Lamp = false;
                ViewBag.Bottom = false;
                ViewBag.Cond = false;
            }
            return View();
        }
        [HttpPost]
        public IActionResult Temp([Bind("Battery,Kotel,Bottom,Kamin,Obigriv,Cond,Lamp")] int userId, Temp temp)
        {
            userId = (int)TempData["userId"];
            Console.WriteLine(userId);
            TempData["userId"] = userId;
            if (!ModelState.IsValid)
            {
                foreach (var val in ModelState.Values)
                {
                    foreach (var error in val.Errors)
                    {
                        Console.WriteLine(error.ErrorMessage);
                    }
                }
                return View(userId);
            }
            var value2 = _service.GetById(userId);
            if (value2 == null)
            {
                temp.UserId = userId;
                _service.Add(temp);
                return RedirectToAction("Index", "Value", new { userId = userId });
            }
            else
            {
                _service.Update(userId, temp);
                return RedirectToAction("Index", "Value", new { userId = userId });
            }
        }
    }
}
