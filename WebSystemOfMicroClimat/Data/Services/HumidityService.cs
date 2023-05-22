using Microsoft.EntityFrameworkCore;
using WebSystemOfMicroClimat.Models;

namespace WebSystemOfMicroClimat.Data.Services
{
    public class HumidityService : IHumidityService
    {
        private readonly AppDbContext _context;
        public HumidityService(AppDbContext context)
        {
            _context = context;
        }
        public void Add(Humidity humidity)
        {
            _context.Add<Humidity>(humidity);
            _context.SaveChanges();
        }

        public void Delete(Humidity humidity)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Humidity>> GetAll()
        {
            var result = await _context.Humidities.ToListAsync();
            return result;
        }

        public Humidity GetById(int id)
        {
            var value = _context.Humidities.FirstOrDefault(x => x.UserId == id);
            return value;
        }

        public Humidity GetHumidity(int userId)
        {
            throw new NotImplementedException();
        }

        public Humidity Update(int id, Humidity humidity)
        {
            var value2 = _context.Humidities.FirstOrDefault(x => x.UserId == id);
            value2.Humidifier = humidity.Humidifier;
            value2.Fan = humidity.Fan;
            value2.Dehydrator = humidity.Dehydrator;
            value2.Protector = humidity.Protector;
            value2.Regulator = humidity.Regulator;
            value2.Hygrometer = humidity.Hygrometer;
            _context.Update(value2);
            _context.SaveChanges();
            return value2;
        }
    }
}
