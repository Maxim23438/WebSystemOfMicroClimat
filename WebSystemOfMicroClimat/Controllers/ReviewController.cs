using Microsoft.AspNetCore.Mvc;
using WebSystemOfMicroClimat.Data.Services;
using WebSystemOfMicroClimat.Models;

namespace WebSystemOfMicroClimat.Controllers
{
    public class ReviewController : Controller
    {
        private readonly IReviewService _service;
        public ReviewController(IReviewService service)
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
        public IActionResult Index([Bind("Grade,Desc")]int userId,Review review)
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
            review.UserId = userId;
            review.User = _service.GetUserById(userId);
            _service.Add(review);
            return RedirectToAction("Index", "Value", new { userId = userId });
        }
        public async Task<IActionResult> All()
        {
            var data = await _service.GetAll();
            return View(data);
        }
    }
}
