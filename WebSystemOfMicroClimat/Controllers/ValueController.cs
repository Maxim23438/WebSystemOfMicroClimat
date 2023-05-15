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
            return View();
        }
        [HttpPost]
        public IActionResult Index([Bind("Temperature")] int userId,Value value) {
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
        
    }
}
