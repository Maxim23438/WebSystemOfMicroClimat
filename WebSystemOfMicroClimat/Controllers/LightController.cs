using Microsoft.AspNetCore.Mvc;
using WebSystemOfMicroClimat.Data.Services;
using WebSystemOfMicroClimat.Models;

namespace WebSystemOfMicroClimat.Controllers
{
    public class LightController : Controller
    {
        private readonly ILightService _service;
        public LightController(ILightService service)
        {
            _service = service;
        }
        public IActionResult Light(int userId)
        {
            userId = (int)TempData["userId"];
            Console.WriteLine($"{userId}");
            TempData["userId"] = userId;
            var user = _service.GetUserById(userId);
            if (user.IsPayment == false)
            {
                TempData["ErrorMessage"] = "Скинь пару шекелів на карту";
                return RedirectToAction("Index", "Value", new { userId = userId });
            }
            var value = _service.GetById(userId);
            if (value != null)
            {
                ViewBag.LampLight = value.LampLight;
                ViewBag.LedLamp = value.LedLamp;
                ViewBag.Curtains = value.Curtains;
                ViewBag.Jalousie = value.Jalousie;
                ViewBag.Reflector = value.Reflector;
                ViewBag.Dimmer = value.Dimmer;
            }
            else
            {
                ViewBag.LampLight = false;
                ViewBag.LedLamp = false;
                ViewBag.Curtains = false;
                ViewBag.Jalousie = false;
                ViewBag.Reflector = false;
                ViewBag.Dimmer = false;
            }
            return View();
        }
        [HttpPost]
        public IActionResult Light([Bind("Dimmer,LampLight,LedLamp,Curtains,Jalousie,Reflector")] int userId, Light light)
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
                light.UserId = userId;
                _service.Add(light);
                return RedirectToAction("Index", "Value", new { userId = userId });
            }
            else
            {
                _service.Update(userId, light);
                return RedirectToAction("Index", "Value", new { userId = userId });
            }
        }
    }
}
