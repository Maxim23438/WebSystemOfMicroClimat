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
        public User GetUserById(int id)
        {
            var value = _context.Users.FirstOrDefault(x => x.UserId == id);
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
        public TempTimeOn GetTimeOnById(int userId)
        {
            var value = _context.TempsTimeOns.FirstOrDefault(x => x.UserId == userId);
            return value;
        }
        public TempTimeOff GetTimeOffById(int userId)
        {
            var value = _context.TempsTimeOffs.FirstOrDefault(x => x.UserId == userId);
            return value;
        }
        public void AddTimeOn(TempTimeOn timeOn)
        {
            _context.TempsTimeOns.Add(timeOn);
            _context.SaveChanges();
        }
        public void AddTimeOff(TempTimeOff timeOff)
        {
            _context.TempsTimeOffs.Add(timeOff);
            _context.SaveChanges();
        }
        public TempTimeOff UpdateTimeOffById(int userId,TempTimeOff timeOff)
        {
            var value = _context.TempsTimeOffs.FirstOrDefault(x => x.UserId == userId);
            value.BatteryOff = timeOff.BatteryOff;
            value.KotelOff = timeOff.KotelOff;
            value.KaminOff = timeOff.KaminOff;
            value.ObigrivOff = timeOff.ObigrivOff;
            value.BottomOff = timeOff.BottomOff;
            value.CondOff = timeOff.CondOff;
            value.LampOff = timeOff.LampOff;
            _context.Update(value);
            _context.SaveChanges();
            return value;
        }
        public TempTimeOn UpdateTimeOnById(int userId, TempTimeOn timeOn)
        {
            var value = _context.TempsTimeOns.FirstOrDefault(x => x.UserId == userId);
            value.BatteryOn = timeOn.BatteryOn;
            value.KotelOn = timeOn.KotelOn;
            value.KaminOn = timeOn.KaminOn;
            value.ObigrivOn = timeOn.ObigrivOn;
            value.BottomOn = timeOn.BottomOn;
            value.CondOn = timeOn.CondOn;
            value.LampOn = timeOn.LampOn;
            _context.Update(value);
            _context.SaveChanges();
            return value;
        }
    }
}
