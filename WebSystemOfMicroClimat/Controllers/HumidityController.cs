using Microsoft.AspNetCore.Mvc;
using WebSystemOfMicroClimat.Data.Services;
using WebSystemOfMicroClimat.Models;

namespace WebSystemOfMicroClimat.Controllers
{
    public class HumidityController : Controller
    {
        private readonly IHumidityService _service;
        public HumidityController(IHumidityService service)
        {
            _service = service;
        }
        public IActionResult Humidity(int userId)
        {
            userId = (int)TempData["userId"];
            Console.WriteLine($"{userId}");
            TempData["userId"] = userId;
            var value = _service.GetById(userId);
            if(value != null ) 
            {
                ViewBag.Humidifier = value.Humidifier;
                ViewBag.Fan = value.Fan;
                ViewBag.Dehydrator = value.Dehydrator;
                ViewBag.Hygrometer = value.Hygrometer;
                ViewBag.Regulator = value.Regulator;
                ViewBag.Protector = value.Protector;
            }
            else
            {
                ViewBag.Humidifier = false;
                ViewBag.Fan = false;
                ViewBag.Dehydrator = false;
                ViewBag.Hygrometer = false;
                ViewBag.Regulator = false;
                ViewBag.Protector = false;
            }
            return View();
        }
        [HttpPost]
        public IActionResult Humidity([Bind("Humidifier,Fan,Dehydrator,Protector,Regulator,Hygrometer")] int userId, Humidity humidity)
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
            //temp.UserId = userId;
            var value2 = _service.GetById(userId);
            if (value2 == null)
            {
                humidity.UserId = userId;
                _service.Add(humidity);
                return RedirectToAction("Index", "Value", new { userId = userId });
            }
            else
            {
                _service.Update(userId, humidity);
                return RedirectToAction("Index", "Value", new { userId = userId });
            }
        }
    }
}
