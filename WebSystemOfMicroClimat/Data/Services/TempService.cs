using Microsoft.EntityFrameworkCore;
using WebSystemOfMicroClimat.Models;

namespace WebSystemOfMicroClimat.Data.Services
{
    public class TempService : ITempService
    {
        private readonly AppDbContext _context;
        public TempService(AppDbContext context)
        {
            _context = context;
        }
        public void Add(Temp temp)
        {
            _context.Temps.Add(temp);
            _context.SaveChanges();
        }

        public void Delete(Temp temp)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Temp>> GetAll()
        {
            var result = await _context.Temps.ToListAsync();
            return result;
        }

        public Temp GetById(int id)
        {
            var value = _context.Temps.FirstOrDefault(x => x.UserId == id);
            return value;
        }

        public Temp GetTemp(int userId)
        {
            throw new NotImplementedException();
        }

        public Temp Update(int id, Temp temp)
        {
            var value2 = _context.Temps.FirstOrDefault(x => x.UserId == id);
            value2.Battery = temp.Battery;
            value2.Kotel = temp.Kotel;
            value2.Kamin = temp.Kamin;
            value2.Obigriv = temp.Obigriv;
            value2.Bottom = temp.Bottom;
            value2.Cond = temp.Cond;
            value2.Lamp = temp.Lamp;
            _context.Update(value2);
            _context.SaveChanges();
            return value2;
        }
    }
}
