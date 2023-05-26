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
            LightTimeOn timeOn = _service.GetTimeOnById(userId);
            if (timeOn == null)
            {
                timeOn = new LightTimeOn();
            }
            LightTimeOff timeOff = _service.GetTimeOffById(userId);
            if (timeOff == null)
            {
                timeOff = new LightTimeOff();
            }
            if (value2 == null)
            {
                light.UserId = userId;
                _service.Add(light);
                if (light.Dimmer)
                {
                    timeOn.DimmerOn = DateTime.Now;
                }
                if (light.Curtains)
                {
                    timeOn.CurtainsOn = DateTime.Now;
                }
                if (light.Reflector)
                {
                    timeOn.ReflectorOn = DateTime.Now;
                }
                if (light.Jalousie)
                {
                    timeOn.JalousieOn = DateTime.Now;
                }
                if (light.LampLight)
                {
                    timeOn.LampLightOn = DateTime.Now;
                }
                if (light.LedLamp)
                {
                    timeOn.LedLampOn = DateTime.Now;
                }
                timeOn.UserId = userId;
                _service.AddTimeOn(timeOn);
                return RedirectToAction("Index", "Value", new { userId = userId });
            }
            else
            {
                _service.Update(userId, light);
                if (timeOn.DimmerOn != null && timeOff.DimmerOff == null)
                {
                    timeOff.DimmerOff = DateTime.Now;
                }
                else
                {
                    timeOn.DimmerOn = DateTime.Now;
                }
                if (timeOn.ReflectorOn != null && timeOff.ReflectorOff == null)
                {
                    timeOff.ReflectorOff = DateTime.Now;
                }
                else
                {
                    timeOn.ReflectorOn = DateTime.Now;
                }
                if (timeOn.CurtainsOn != null && timeOff.CurtainsOff == null)
                {
                    timeOff.CurtainsOff = DateTime.Now;
                }
                else
                {
                    timeOn.CurtainsOn = DateTime.Now;
                }
                if (timeOn.JalousieOn != null && timeOff.JalousieOff == null)
                {
                    timeOff.JalousieOff = DateTime.Now;
                }
                else
                {
                    timeOn.JalousieOn = DateTime.Now;
                }
                if (timeOn.LampLightOn!= null && timeOff.LampLightOff == null)
                {
                    timeOff.LampLightOff = DateTime.Now;
                }
                else
                {
                    timeOn.LampLightOn = DateTime.Now;
                }
                if (timeOn.LedLampOn != null && timeOff.LedLampOff == null)
                {
                    timeOff.LedLampOff = DateTime.Now;
                }
                else
                {
                    timeOn.LedLampOn = DateTime.Now;
                }
                _service.UpdateTimeOnById(userId, timeOn);
                if (timeOff.Id == 0)
                {
                    timeOff.UserId = userId;
                    _service.AddTimeOff(timeOff);
                }
                else
                {
                    _service.UpdateTimeOffById(userId, timeOff);
                }
                return RedirectToAction("Index", "Value", new { userId = userId });
            }
        }
    }
}
