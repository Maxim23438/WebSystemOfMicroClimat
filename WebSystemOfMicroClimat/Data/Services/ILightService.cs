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
    }
}
