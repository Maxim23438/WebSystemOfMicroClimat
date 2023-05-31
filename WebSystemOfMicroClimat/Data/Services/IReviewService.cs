using WebSystemOfMicroClimat.Models;

namespace WebSystemOfMicroClimat.Data.Services
{
    public interface IReviewService
    {
        Task<IEnumerable<Review>> GetAll();
        Review GetById(int id);
        void Add(Review review);
        Review Update(int id, Review review);
        void Delete(Review review);
        User GetUserById(int id);
    }
}
