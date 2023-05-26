using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebSystemOfMicroClimat.Data;
using WebSystemOfMicroClimat.Data.Services;
using WebSystemOfMicroClimat.Models;

namespace WebSystemOfMicroClimat.Controllers
{
    public class ValueController : Controller
    {
        private readonly IValuesService _service;
        public ValueController(IValuesService service)
        {
            _service = service;
        }
        public IActionResult Index(int userId)
        {
            userId = (int)TempData["userId"];
            Console.WriteLine(userId);
            TempData["userId"] = userId;
            var value2 = _service.GetById(userId);
            if (value2 != null) {
                ViewBag.Humidity = value2.Humidity;
                ViewBag.Temperature = value2.Temperature;
                ViewBag.Light = value2.Light;
            }
            return View();
        }
        [HttpPost]
        public IActionResult Index([Bind("Temperature")] int userId, Value value) {
            userId = (int)TempData["userId"];
            Console.WriteLine(userId);
            string errorM = TempData["ErrorMessage"] as string;
            ViewBag.ErrorM = errorM;
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
            if (value.Temperature > 23 || value.Temperature < 15)
            {
                ViewBag.ErrorMessage = "Температура повинна бути в межах від 15 до 23 градусів Цельсія";
                TempData["userId"] = userId;
                return View();
            }
            value.UserId = userId;
            var value2 = _service.GetById(userId);
            if (value2 == null)
            {
                _service.Add(value);
                return RedirectToAction("Index", "Value", new { userId = userId });
            }
            else
            {
                _service.Update(userId, value);
                return RedirectToAction("Index", "Value", new { userId = userId });
            }
        }
        [HttpPost]
        public IActionResult Index2([Bind("Humidity")] int userId, Value value)
        {
            userId = (int)TempData["userId"];
            Console.WriteLine(userId);
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
            if (value.Humidity > 60 || value.Humidity < 40)
            {
                ViewBag.ErrorMessage2 = "Вологість повинна бути в межах від 40 до 60 %";
                TempData["userId"] = userId;
                return View("Index");
            }
            value.UserId = userId;
            var value2 = _service.GetById(userId);
            if (value2 == null)
            {
                _service.Add(value);
                return RedirectToAction("Index", "Value", new { userId = userId });
            }
            else
            {
                _service.Update2(userId, value);
                return RedirectToAction("Index", "Value", new { userId = userId });
            }
        }

        [HttpPost]
        public IActionResult Index3([Bind("Light")] int userId, Value value)
        {
            userId = (int)TempData["userId"];
            Console.WriteLine(userId);
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
            if (value.Light > 500 || value.Light < 300)
            {
                ViewBag.ErrorMessage3 = "Освітлення повинна бути в межах від 300 до 500 люменів";
                TempData["userId"] = userId;
                return View("Index");
            }
            value.UserId = userId;
            var value2 = _service.GetById(userId);
            if (value2 == null)
            {
                _service.Add(value);
                return RedirectToAction("Index", "Value", new { userId = userId });
            }
            else
            {
                _service.Update3(userId, value);
                return RedirectToAction("Index", "Value", new { userId = userId });
            }
        }
        public IActionResult Plan(int userId)
        {
            userId = (int)TempData["userId"];
            Console.WriteLine(userId);
            TempData["userId"] = userId;
            return View();
        }
        
        public IActionResult Cab(int userId)
        {
            userId = (int)TempData["userId"];
            Console.WriteLine(userId);
            TempData["userId"] = userId;
            var value2 = _service.GetById(userId);
            var temp = _service.GetTempById(userId);
            var humidity = _service.GetHumidityById(userId);
            var light = _service.GetLightById(userId);
            var user = _service.GetUserById(userId);
            ViewBag.Name = user.Name;
            ViewBag.Email = user.Email;
            var timeOn = _service.GetTimeOnById(userId);
            var timeOff = _service.GetTimeOffById(userId);
            var LtimeOn = _service.GetLTimeOnById(userId);
            var LtimeOff = _service.GetLTimeOffById(userId);
            var HtimeOn = _service.GetHTimeOnById(userId);
            var HtimeOff = _service.GetHTimeOffById(userId);
            if (value2 != null)
            {
                ViewBag.Humidity = value2.Humidity;
                ViewBag.Temperature = value2.Temperature;
                ViewBag.Light = value2.Light;
            }
            else
            {
                ViewBag.Humidity = 0;
                ViewBag.Temperature = 0;
                ViewBag.Light = 0;
            }
            if(temp != null)
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
            if(humidity != null)
            {
                ViewBag.Humidifier = humidity.Humidifier;
                ViewBag.Fan = humidity.Fan;
                ViewBag.Dehydrator = humidity.Dehydrator;
                ViewBag.Hygrometer = humidity.Hygrometer;
                ViewBag.Regulator = humidity.Regulator;
                ViewBag.Protector = humidity.Protector;
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
            if(light != null)
            {
                ViewBag.LampLight = light.LampLight;
                ViewBag.LedLamp = light.LedLamp;
                ViewBag.Curtains = light.Curtains;
                ViewBag.Jalousie = light.Jalousie;
                ViewBag.Reflector = light.Reflector;
                ViewBag.Dimmer = light.Dimmer;
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
            if(timeOn != null)
            {
                ViewBag.BatteryOn = timeOn.BatteryOn;
                ViewBag.BottomOn = timeOn.BottomOn;
                ViewBag.CondOn = timeOn.CondOn;
                ViewBag.KotelOn = timeOn.KotelOn;
                ViewBag.KaminOn = timeOn.KaminOn;
                ViewBag.LampOn = timeOn.LampOn;
                ViewBag.ObigrivOn = timeOn.ObigrivOn;
            }
            if(timeOff != null)
            {
                ViewBag.BatteryOff = timeOff.BatteryOff;
                ViewBag.BottomOff = timeOff.BottomOff;
                ViewBag.CondOff = timeOff.CondOff;
                ViewBag.KotelOff = timeOff.KotelOff;
                ViewBag.KaminOff = timeOff.KaminOff;
                ViewBag.LampOff = timeOff.LampOff;
                ViewBag.ObigrivOff = timeOff.ObigrivOff;
            }
            if(LtimeOn != null)
            {
                ViewBag.LampLightOn = LtimeOn.LampLightOn;
                ViewBag.LedLampOn = LtimeOn.LedLampOn;
                ViewBag.DimmerOn = LtimeOn.DimmerOn;
                ViewBag.JalousieOn = LtimeOn.JalousieOn;
                ViewBag.CurtainsOn = LtimeOn.CurtainsOn;
                ViewBag.ReflectorOn = LtimeOn.ReflectorOn;
            }
            if (LtimeOff != null)
            {
                ViewBag.LampLightOff = LtimeOff.LedLampOff;
                ViewBag.LedLampOff = LtimeOff.LedLampOff;
                ViewBag.DimmerOff = LtimeOff.DimmerOff;
                ViewBag.JalousieOff = LtimeOff.JalousieOff;
                ViewBag.CurtainsOff = LtimeOff.CurtainsOff;
                ViewBag.ReflectorOff = LtimeOff.ReflectorOff;
            }
            if (HtimeOn != null)
            {
                ViewBag.HumidifierOn = HtimeOn.HumidifierOn;
                ViewBag.DehydratorOn = HtimeOn.DehydratorOn;
                ViewBag.HygrometerOn = HtimeOn.HygrometerOn;
                ViewBag.ProtectorOn = HtimeOn.ProtectorOn;
                ViewBag.FanOn = HtimeOn.FanOn;
                ViewBag.RegulatorOn = HtimeOn.RegulatorOn;
            }
            if (HtimeOff != null)
            {
                ViewBag.HumidifierOff = HtimeOff.HumidifierOff;
                ViewBag.DehydratorOff = HtimeOff.DehydratorOff;
                ViewBag.HygrometerOff = HtimeOff.HygrometerOff;
                ViewBag.ProtectorOff = HtimeOff.ProtectorOff;
                ViewBag.FanOff = HtimeOff.FanOff;
                ViewBag.RegulatorOff = HtimeOff.RegulatorOff;
            }
            return View();
        }

    }
    
}
