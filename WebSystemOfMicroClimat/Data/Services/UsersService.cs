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
            var user = _context.Users.FirstOrDefault(x => x.UserId == id);
            return user;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            var result = await _context.Users.ToListAsync();
            return result;
        }

        public User Update(int id, User user)
        {
            var value2 = _context.Users.FirstOrDefault(x => x.UserId == id);
            value2.Name = user.Name;
            value2.UserId = id;
            value2.Email = user.Email;
            value2.Password = user.Password;
            value2.IsPayment = user.IsPayment;
            _context.Update(value2);
            _context.SaveChanges();
            return value2;
        }

        public User GetUser(string name)
        {
            var user = _context.Users.FirstOrDefault(x => x.Name == name);
            return user;
        }
        public User GetEmail(string email)
        {
            var user = _context.Users.FirstOrDefault(x => x.Email == email);
            return user;
        }
        public Admin GetAdmin(string name)
        {
            var user = _context.Admins.FirstOrDefault(x => x.Name == name);
            return user;
        }
    }
}
