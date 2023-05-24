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
        User GetUserById(int id);
        TempTimeOn GetTimeOnById(int userId);
        TempTimeOff GetTimeOffById(int userId);
        void AddTimeOn(TempTimeOn timeOn);
        void AddTimeOff(TempTimeOff timeOff);
        TempTimeOff UpdateTimeOffById(int userId, TempTimeOff timeOff);
        TempTimeOn UpdateTimeOnById(int userId, TempTimeOn timeOn);
    }
}
