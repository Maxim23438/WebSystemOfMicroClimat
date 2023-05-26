using WebSystemOfMicroClimat.Models;

namespace WebSystemOfMicroClimat.Data.Services
{
    public interface ILightService
    {
        Task<IEnumerable<Light>> GetAll();
        Light GetById(int id);
        void Add(Light light);
        Light Update(int id, Light light);
        void Delete(Light light);
        Light GetLight(int userId);
        User GetUserById(int id);
        LightTimeOn GetTimeOnById(int userId);
        LightTimeOff GetTimeOffById(int userId);
        void AddTimeOn(LightTimeOn timeOn);
        void AddTimeOff(LightTimeOff timeOff);
        LightTimeOff UpdateTimeOffById(int userId, LightTimeOff timeOff);
        LightTimeOn UpdateTimeOnById(int userId, LightTimeOn timeOn);
    }
}
