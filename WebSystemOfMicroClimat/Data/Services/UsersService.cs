using Microsoft.EntityFrameworkCore;
using WebSystemOfMicroClimat.Models;

namespace WebSystemOfMicroClimat.Data.Services
{
    public class UsersService : IUsersService
    {
        private readonly AppDbContext _context;
        public UsersService(AppDbContext context)
        {
            _context = context;
        }
        public void Add(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void Delete(User user)
        {
            throw new NotImplementedException();
        }

        public User GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            var result = await _context.Users.ToListAsync();
            return result;
        }

        public User Update(int id, User user)
        {
            throw new NotImplementedException();
        }

        public User GetUser(string name)
        {
            var user = _context.Users.FirstOrDefault(x => x.Name == name);
            return user;
        }
    }
}
