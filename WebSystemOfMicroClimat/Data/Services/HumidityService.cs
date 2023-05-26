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
        public User GetUserById(int id)
        {
            var value = _context.Users.FirstOrDefault(x => x.UserId == id);
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

        public HumTimeOn GetTimeOnById(int userId)
        {
            var value = _context.HumTimeOns.FirstOrDefault(x => x.UserId == userId);
            return value;
        }

        public HumTimeOff GetTimeOffById(int userId)
        {
            var value = _context.HumTimeOffs.FirstOrDefault(x => x.UserId == userId);
            return value;
        }

        public void AddTimeOn(HumTimeOn timeOn)
        {
            _context.HumTimeOns.Add(timeOn);
            _context.SaveChanges();
        }

        public void AddTimeOff(HumTimeOff timeOff)
        {
            _context.HumTimeOffs.Add(timeOff);
            _context.SaveChanges();
        }

        public HumTimeOff UpdateTimeOffById(int userId, HumTimeOff timeOff)
        {
            var value = _context.HumTimeOffs.FirstOrDefault(x => x.UserId == userId);
            value.HumidifierOff = timeOff.HumidifierOff;
            value.FanOff = timeOff.FanOff;
            value.ProtectorOff = timeOff.ProtectorOff;
            value.HygrometerOff = timeOff.HygrometerOff;
            value.DehydratorOff = timeOff.DehydratorOff;
            value.RegulatorOff = timeOff.RegulatorOff;
            _context.Update(value);
            _context.SaveChanges();
            return value;
        }

        public HumTimeOn UpdateTimeOnById(int userId, HumTimeOn timeOn)
        {
            var value = _context.HumTimeOns.FirstOrDefault(x => x.UserId == userId);
            value.HumidifierOn = timeOn.HumidifierOn;
            value.FanOn = timeOn.FanOn;
            value.ProtectorOn = timeOn.ProtectorOn;
            value.HygrometerOn = timeOn.HygrometerOn;
            value.DehydratorOn = timeOn.DehydratorOn;
            value.RegulatorOn = timeOn.RegulatorOn;
            _context.Update(value);
            _context.SaveChanges();
            return value;
        }
    }
}
