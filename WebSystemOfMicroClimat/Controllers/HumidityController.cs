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
            var user = _service.GetUserById(userId);
            if (user.IsPayment == false)
            {
                TempData["ErrorMessage"] = "Скинь пару шекелів на карту";
                return RedirectToAction("Index", "Value", new { userId = userId });
            }
            if (value != null ) 
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
            HumTimeOn timeOn = _service.GetTimeOnById(userId);
            if (timeOn == null)
            {
                timeOn = new HumTimeOn();
            }
            HumTimeOff timeOff = _service.GetTimeOffById(userId);
            if (timeOff == null)
            {
                timeOff = new HumTimeOff();
            }
            if (value2 == null)
            {
                humidity.UserId = userId;
                _service.Add(humidity);
                if (humidity.Humidifier)
                {
                    timeOn.HumidifierOn = DateTime.Now;
                }
                if (humidity.Fan)
                {
                    timeOn.FanOn = DateTime.Now;
                }
                if (humidity.Dehydrator)
                {
                    timeOn.DehydratorOn = DateTime.Now;
                }
                if (humidity.Hygrometer)
                {
                    timeOn.HygrometerOn = DateTime.Now;
                }
                if (humidity.Protector)
                {
                    timeOn.ProtectorOn = DateTime.Now;
                }
                if (humidity.Regulator)
                {
                    timeOn.RegulatorOn = DateTime.Now;
                }
                timeOn.UserId = userId;
                _service.AddTimeOn(timeOn);
                return RedirectToAction("Index", "Value", new { userId = userId });
            }
            else
            {
                _service.Update(userId, humidity);
                if (timeOn.HumidifierOn != null && timeOff.HumidifierOff == null)
                {
                    timeOff.HumidifierOff = DateTime.Now;
                }
                else
                {
                    timeOn.HumidifierOn = DateTime.Now;
                }
                if (timeOn.DehydratorOn != null && timeOff.DehydratorOff == null)
                {
                    timeOff.DehydratorOff = DateTime.Now;
                }
                else
                {
                    timeOn.DehydratorOn = DateTime.Now;
                }
                if (timeOn.FanOn != null && timeOff.FanOff == null)
                {
                    timeOff.FanOff = DateTime.Now;
                }
                else
                {
                    timeOn.FanOn = DateTime.Now;
                }
                if (timeOn.HygrometerOn != null && timeOff.HygrometerOff == null)
                {
                    timeOff.HygrometerOff = DateTime.Now;
                }
                else
                {
                    timeOn.HygrometerOn = DateTime.Now;
                }
                if (timeOn.RegulatorOn != null && timeOff.RegulatorOff == null)
                {
                    timeOff.RegulatorOff = DateTime.Now;
                }
                else
                {
                    timeOn.RegulatorOn = DateTime.Now;
                }
                if (timeOn.ProtectorOn != null && timeOff.ProtectorOff == null)
                {
                    timeOff.ProtectorOff = DateTime.Now;
                }
                else
                {
                    timeOn.ProtectorOn = DateTime.Now;
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
