using WebSystemOfMicroClimat.Models;

namespace WebSystemOfMicroClimat.Data.Services
{
    public interface IHumidityService
    {
        Task<IEnumerable<Humidity>> GetAll();
        Humidity GetById(int id);
        void Add(Humidity humidity);
        Humidity Update(int id, Humidity humidity);
        void Delete(Humidity humidity);
        Humidity GetHumidity(int userId);
        User GetUserById(int id);
        HumTimeOn GetTimeOnById(int userId);
        HumTimeOff GetTimeOffById(int userId);
        void AddTimeOn(HumTimeOn timeOn);
        void AddTimeOff(HumTimeOff timeOff);
        HumTimeOff UpdateTimeOffById(int userId, HumTimeOff timeOff);
        HumTimeOn UpdateTimeOnById(int userId, HumTimeOn timeOn);
    }
}
