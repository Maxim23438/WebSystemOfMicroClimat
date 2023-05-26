using WebSystemOfMicroClimat.Models;

namespace WebSystemOfMicroClimat.Data.Services
{
    public interface IValuesService
    {
        Task<IEnumerable<Value>> GetAll();
        Value GetById(int id);
        Temp GetTempById(int id);
        Humidity GetHumidityById(int id);
        Light GetLightById(int id);
        void Add(Value value);
        Value Update(int id, Value value);
        void Delete(Value value);
        Value Update2(int id, Value value);
        Value Update3(int id, Value value);
        User GetUserById(int id);
        TempTimeOn GetTimeOnById(int userId);
        
        TempTimeOff GetTimeOffById(int userId);
        LightTimeOff GetLTimeOffById(int userId);
        LightTimeOn GetLTimeOnById(int userId);
        HumTimeOn GetHTimeOnById(int userId);
        HumTimeOff GetHTimeOffById(int userId);
    }
}
