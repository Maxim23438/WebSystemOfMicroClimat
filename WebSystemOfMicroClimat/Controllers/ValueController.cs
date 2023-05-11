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
            TempData["userId"] = userId;
            return View();
        }
        [HttpPost]
        public IActionResult Index([Bind("Temperature")] int userId,Value value) {
            userId = (int)TempData["userId"];
            Console.WriteLine(userId);
            return View();
        }
    }
}
