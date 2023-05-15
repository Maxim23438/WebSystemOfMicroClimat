using WebSystemOfMicroClimat.Models;

namespace WebSystemOfMicroClimat.Data.Services
{
    public interface IValuesService
    {
        Task<IEnumerable<Value>> GetAll();
        Value GetById(int id);
        void Add(Value value);
        Value Update(int id, Value value);
        void Delete(Value value);
        Value Update2(int id, Value value);
        Value Update3(int id, Value value);
    }
}
