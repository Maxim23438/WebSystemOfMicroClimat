using WebSystemOfMicroClimat.Models;

namespace WebSystemOfMicroClimat.Data.Services
{
    public interface ITempService
    {
        Task<IEnumerable<Temp>> GetAll();
        Temp GetById(int id);
        void Add(Temp temp);
        Temp Update(int id, Temp temp);
        void Delete(Temp temp);
        Temp GetTemp(int userId);
    }
}
