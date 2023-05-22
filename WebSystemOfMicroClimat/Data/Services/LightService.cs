using Microsoft.EntityFrameworkCore;
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
    }
}
