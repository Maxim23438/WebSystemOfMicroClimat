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
    }
}
