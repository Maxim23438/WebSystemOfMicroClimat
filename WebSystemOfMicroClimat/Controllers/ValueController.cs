using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebSystemOfMicroClimat.Data;

namespace WebSystemOfMicroClimat.Controllers
{
    public class ValueController : Controller
    {
        private readonly AppDbContext _context;
        public ValueController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(int userId)
        {
            var user = _context.Users.FirstOrDefault(u => u.UserId == userId);
            var allValues = await _context.Values.ToListAsync();
            return View();
        }
    }
}
