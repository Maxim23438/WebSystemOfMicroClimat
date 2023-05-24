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
            var user = _service.GetUserById(userId);
            if (user.IsPayment == false)
            {
                TempData["ErrorMessage"] = "Скинь пару шекелів на карту";
                return RedirectToAction("Index", "Value", new { userId = userId });
            }
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
            TempTimeOn timeOn = _service.GetTimeOnById(userId);
            if(timeOn == null)
            {
                timeOn = new TempTimeOn();
            }
            TempTimeOff timeOff = _service.GetTimeOffById(userId);
            if(timeOff == null)
            {
                timeOff = new TempTimeOff();
            }
            if (value2 == null)
            {
                temp.UserId = userId;
                _service.Add(temp);
                if(temp.Battery)
                {
                    timeOn.BatteryOn = DateTime.Now;
                }
                if(temp.Bottom)
                {
                    timeOn.BottomOn = DateTime.Now;
                }
                if (temp.Kotel)
                {
                    timeOn.KotelOn = DateTime.Now;
                }
                if (temp.Kamin)
                {
                    timeOn.KaminOn = DateTime.Now;
                }
                if (temp.Obigriv)
                {
                    timeOn.ObigrivOn = DateTime.Now;
                }
                if (temp.Cond)
                {
                    timeOn.CondOn = DateTime.Now;
                }
                if (temp.Lamp)
                {
                    timeOn.LampOn = DateTime.Now;
                }
                timeOn.UserId = userId;
                _service.AddTimeOn(timeOn);
                return RedirectToAction("Index", "Value", new { userId = userId });
            }
            else
            {
                _service.Update(userId, temp);
                if(timeOn.BatteryOn != null && timeOff.BatteryOff == null)
                {
                    timeOff.BatteryOff = DateTime.Now;
                }
                else
                {
                    timeOn.BatteryOn = DateTime.Now;
                }
                if (timeOn.BottomOn != null && timeOff.BottomOff == null)
                {
                    timeOff.BottomOff = DateTime.Now;
                }
                else
                {
                    timeOn.BottomOn = DateTime.Now;
                }
                if (timeOn.CondOn != null && timeOff.CondOff == null)
                {
                    timeOff.CondOff = DateTime.Now;
                }
                else
                {
                    timeOn.CondOn = DateTime.Now;
                }
                if (timeOn.KaminOn != null && timeOff.KaminOff == null)
                {
                    timeOff.KaminOff = DateTime.Now;
                }
                else
                {
                    timeOn.KaminOn = DateTime.Now;
                }
                if (timeOn.KotelOn != null && timeOff.KotelOff == null)
                {
                    timeOff.KotelOff = DateTime.Now;
                }
                else
                {
                    timeOn.KotelOn = DateTime.Now;
                }
                if (timeOn.LampOn != null && timeOff.LampOff == null)
                {
                    timeOff.LampOff = DateTime.Now;
                }
                else
                {
                    timeOn.LampOn = DateTime.Now;
                }
                if (timeOn.ObigrivOn != null && timeOff.ObigrivOff == null)
                {
                    timeOff.ObigrivOff = DateTime.Now;
                }
                else
                {
                    timeOn.ObigrivOn = DateTime.Now;
                }
                _service.UpdateTimeOnById(userId, timeOn);
                if(timeOff.Id == 0)
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
