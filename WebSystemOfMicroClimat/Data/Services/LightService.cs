using Microsoft.EntityFrameworkCore;
using System.Threading;
using WebSystemOfMicroClimat.Models;

namespace WebSystemOfMicroClimat.Data.Services
{
    public class LightService:ILightService
    {
        private readonly AppDbContext _context;
        public LightService(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Light light)
        {
            _context.Add<Light>(light);
            _context.SaveChanges();
        }

        public void Delete(Light light)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Light>> GetAll()
        {
            var result = await _context.Lights.ToListAsync();
            return result;
        }

        public Light GetById(int id)
        {
            var value = _context.Lights.FirstOrDefault(x => x.UserId == id);
            return value;
        }
        public User GetUserById(int id)
        {
            var value = _context.Users.FirstOrDefault(x => x.UserId == id);
            return value;
        }

        public Light GetLight(int userId)
        {
            throw new NotImplementedException();
        }

        public Light Update(int id, Light light)
        {
            var value2 = _context.Lights.FirstOrDefault(x => x.UserId == id);
            value2.Dimmer = light.Dimmer;
            value2.LampLight = light.LampLight;
            value2.LedLamp = light.LedLamp;
            value2.Curtains = light.Curtains;
            value2.Jalousie = light.Jalousie;
            value2.Reflector = light.Reflector;
            _context.Update(value2);
            _context.SaveChanges();
            return value2;
        }

        public LightTimeOn GetTimeOnById(int userId)
        {
            var value = _context.LightTimeOns.FirstOrDefault(x => x.UserId == userId);
            return value;
        }

        public LightTimeOff GetTimeOffById(int userId)
        {
            var value = _context.LightTimeOffs.FirstOrDefault(x => x.UserId == userId);
            return value;
        }

        public void AddTimeOn(LightTimeOn timeOn)
        {
            _context.LightTimeOns.Add(timeOn);
            _context.SaveChanges();
        }

        public void AddTimeOff(LightTimeOff timeOff)
        {
            _context.LightTimeOffs.Add(timeOff);
            _context.SaveChanges();
        }

        public LightTimeOff UpdateTimeOffById(int userId, LightTimeOff timeOff)
        {
            var value = _context.LightTimeOffs.FirstOrDefault(x => x.UserId == userId);
            value.DimmerOff = timeOff.DimmerOff;
            value.LampLightOff = timeOff.LampLightOff;
            value.LedLampOff = timeOff.LedLampOff;
            value.ReflectorOff = timeOff.ReflectorOff;
            value.CurtainsOff = timeOff.CurtainsOff;
            value.JalousieOff = timeOff.JalousieOff;
            _context.Update(value);
            _context.SaveChanges();
            return value;
        }

        public LightTimeOn UpdateTimeOnById(int userId, LightTimeOn timeOn)
        {
            var value = _context.LightTimeOns.FirstOrDefault(x => x.UserId == userId);
            value.DimmerOn = timeOn.DimmerOn;
            value.LampLightOn = timeOn.LampLightOn;
            value.LedLampOn = timeOn.LedLampOn;
            value.ReflectorOn = timeOn.ReflectorOn;
            value.CurtainsOn = timeOn.CurtainsOn;
            value.JalousieOn = timeOn.JalousieOn;
            _context.Update(value);
            _context.SaveChanges();
            return value;
        }
    }
}
