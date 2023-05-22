using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using WebSystemOfMicroClimat.Data;
using WebSystemOfMicroClimat.Data.Services;
using WebSystemOfMicroClimat.Models;
using System.Security.Cryptography;
using System.Text;

namespace WebSystemOfMicroClimat.Controllers
{
    public class UserController : Controller
    {
        private readonly IUsersService _service;
        public UserController(IUsersService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAll();
            return View(data);
        }
        public IActionResult Create() {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Name,Email,Password,House,Flat,GreenHouse")]User user)
        {
            if (!ModelState.IsValid)
            {
                foreach (var value in ModelState.Values)
                {
                    foreach (var error in value.Errors)
                    {
                        Console.WriteLine(error.ErrorMessage);
                    }
                }
                return View(user);
            }
            var md5 = MD5.Create();
            byte[] hashedBytes = md5.ComputeHash(Encoding.UTF8.GetBytes(user.Password));
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hashedBytes.Length; i++)
            {
                sb.Append(hashedBytes[i].ToString("x2"));
            }
            user.Password = sb.ToString();
            var user2 = _service.GetUser(user.Name);
            var user3 = _service.GetEmail(user.Email);
            if(user2 != null && user3 != null)
            {
                ViewBag.ErrorMessage = "Користувач з такмм іменем уже існує";
                ViewBag.ErrorMessage2 = "Користувач з такою поштою уже існує";
                return View();
            }
            if(user2 != null)
            {
                ViewBag.ErrorMessage = "Користувач з таким іменем уже існує";
                return View();
            }
            if (user3 != null)
            {
                ViewBag.ErrorMessage2 = "Користувач з такою поштою уже існує";
                return View();
            }
            if (user2 == null && user3 == null)
            {
                _service.Add(user);
                TempData["userId"] = user.UserId;
                return RedirectToAction("Index", "Value", new { userId = user.UserId });
            }
            return View();

        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login([Bind("Name,Password")] User user)
        {
            var user2 = _service.GetUser(user.Name);
            var md5 = MD5.Create();
            byte[] hashedBytes = md5.ComputeHash(Encoding.UTF8.GetBytes(user.Password));
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hashedBytes.Length; i++)
            {
                sb.Append(hashedBytes[i].ToString("x2"));
            }
            user.Password = sb.ToString();
            if (user2 != null && user2.Password == user.Password) {
                TempData["userId"] = user2.UserId;
                return RedirectToAction("Index", "Value", new { userId = user2.UserId });
            }
            else
            {
                ViewBag.ErrorMessage = "Неправильний логін або пароль";
                return View();
            }
        }
    }
}
