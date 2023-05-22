using Microsoft.EntityFrameworkCore;
using WebSystemOfMicroClimat.Models;

namespace WebSystemOfMicroClimat.Data.Services
{
    public class ValuesService : IValuesService
    {
        private readonly AppDbContext _context;
        public ValuesService(AppDbContext context)
        {
            _context = context;
        }
        public void Add(Value value)
        {
            _context.Values.Add(value);
            _context.SaveChanges();
        }

        public void Delete(Value value)
        {
            throw new NotImplementedException();
        }
        public User GetUserById(int id)
        {
            var value = _context.Users.FirstOrDefault(x => x.UserId == id);
            return value;
        }
        public Value GetById(int id)
        {
            var value = _context.Values.FirstOrDefault(x => x.UserId == id);
            return value;
        }
        public Temp GetTempById(int id)
        {
            var value = _context.Temps.FirstOrDefault(x => x.UserId == id);
            return value;
        }
        public Humidity GetHumidityById(int id)
        {
            var value = _context.Humidities.FirstOrDefault(x => x.UserId == id);
            return value;
        }
        public Light GetLightById(int id)
        {
            var value = _context.Lights.FirstOrDefault(x => x.UserId == id);
            return value;
        }

        public async Task<IEnumerable<Value>> GetAll()
        {
            var result = await _context.Values.ToListAsync();
            return result;
        }

        public Value Update(int id, Value value)
        {
            var value2 = _context.Values.FirstOrDefault(x => x.UserId == id);
            value2.Temperature = value.Temperature;
            value2.UserId = id;
            _context.Update(value2);
            _context.SaveChanges();
            return value2;
        
        }
        public Value Update2(int id, Value value)
        {
            var value2 = _context.Values.FirstOrDefault(x => x.UserId == id);
            value2.Humidity = value.Humidity;
            value2.UserId = id;
            _context.Update(value2);
            _context.SaveChanges();
            return value2;

        }
        public Value Update3(int id, Value value)
        {
            var value2 = _context.Values.FirstOrDefault(x => x.UserId == id);
            value2.Light = value.Light;
            value2.UserId = id;
            _context.Update(value2);
            _context.SaveChanges();
            return value2;

        }
    }
}
