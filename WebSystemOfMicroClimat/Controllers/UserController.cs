﻿using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using WebSystemOfMicroClimat.Data;
using WebSystemOfMicroClimat.Data.Services;
using WebSystemOfMicroClimat.Models;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace WebSystemOfMicroClimat.Controllers
{
    public class UserController : Controller
    {
        private readonly IUsersService _service;
        private readonly IEmailService _emailService;
        public UserController(IUsersService service, IEmailService emailService)
        {
            _service = service;
            _emailService = emailService;
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
            user.IsPayment = false;
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
                _emailService.SendEmail(user.Email, "Реєстрація успішна", "Ви успішно зареєструвалися на нашому сайті.");
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
        public IActionResult AdminLogin()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AdminLogin([Bind("Name,Password")] Admin admin)
        {
            var user2 = _service.GetAdmin(admin.Name);
            if (user2 != null && user2.Password == admin.Password)
            {
                return RedirectToAction("Index", "User");
            }
            else
            {
                ViewBag.ErrorMessage = "Неправильний логін або пароль";
                return View();
            }
        }
        public IActionResult EditUser(int userId)
        {
            Console.WriteLine(userId);
            var user = _service.GetById(userId);
            if (user != null)
            {
                return View(user);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        public IActionResult EditUser(int userId,bool IsPayment)
        {
            var value2 = _service.GetById(userId);
            value2.IsPayment = IsPayment;
            if (ModelState.IsValid)
            {
                // Зберегти зміни користувача в БД
                _service.Update(userId,value2);

                return RedirectToAction("Index", "User"); // Повернутись до сторінки зі списком користувачів, наприклад
            }
            else
            {
                foreach (var value in ModelState.Values)
                {
                    foreach (var error in value.Errors)
                    {
                        Console.WriteLine(error.ErrorMessage);
                    }
                }
                return View(value2);
            }

        }
        public IActionResult Password()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Password([Bind("Name,Password")] User user)
        {
            var user2 = _service.GetUser(user.Name);
            if (user2 != null)
            {
                var md5 = MD5.Create();
                byte[] hashedBytes = md5.ComputeHash(Encoding.UTF8.GetBytes(user.Password));
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashedBytes.Length; i++)
                {
                    sb.Append(hashedBytes[i].ToString("x2"));
                }
                user2.Password = sb.ToString();
                TempData["userId"] = user2.UserId;
                _service.Update(user2.UserId, user2);
                return RedirectToAction("Index", "Value", new { userId = user2.UserId });
            }
            return View();
        }
    }
}
