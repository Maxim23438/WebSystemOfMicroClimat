using Microsoft.EntityFrameworkCore;
using WebSystemOfMicroClimat.Models;

namespace WebSystemOfMicroClimat.Data.Services
{
    public class ReviewService : IReviewService
    {
        private readonly AppDbContext _context;
        public ReviewService(AppDbContext context)
        {
            _context = context;
        }
        public void Add(Review review)
        {
            _context.Reviews.Add(review);
            _context.SaveChanges();
        }

        public void Delete(Review review)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Review>> GetAll()
        {
            var reviews = await _context.Reviews.ToListAsync();

            foreach (var review in reviews)
            {
                var user = await _context.Users.FindAsync(review.UserId);
                review.User = user;
            }

            return reviews;
        }

        public Review GetById(int id)
        {
            throw new NotImplementedException();
        }

        public User GetUserById(int id)
        {
            var value = _context.Users.FirstOrDefault(x => x.UserId == id);
            return value;
        }

        public Review Update(int id, Review review)
        {
            throw new NotImplementedException();
        }
    }
}
