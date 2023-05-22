using WebSystemOfMicroClimat.Models;

namespace WebSystemOfMicroClimat.Data.Services
{
    public interface IUsersService
    {
        Task<IEnumerable<User>> GetAll();
        User GetById(int id);
        void Add(User user);
        User Update(int id,User user);
        void Delete(User user);
        User GetUser(string name);
        User GetEmail(string email);
    }
}
