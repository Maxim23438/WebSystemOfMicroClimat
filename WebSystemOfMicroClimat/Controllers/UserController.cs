using Microsoft.AspNetCore.Mvc;
using WebSystemOfMicroClimat.Data;

namespace WebSystemOfMicroClimat.Controllers
{
    public class UserController : Controller
    {
        private readonly AppDbContext _context;
        public UserController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var data = _context.Users.ToList();
            return View(data);
        }
    }
}
