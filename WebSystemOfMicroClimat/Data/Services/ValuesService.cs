using Microsoft.EntityFrameworkCore;
using WebSystemOfMicroClimat.Models;

namespace WebSystemOfMicroClimat.Data.Services
{
    public class ValuesService : IValuesService
    {
        private readonly AppDbContext _context;
        public ValuesService(AppDbContext context)
        {
            _context = context;
        }
        public void Add(Value value)
        {
            _context.Values.Add(value);
            _context.SaveChanges();
        }

        public void Delete(Value value)
        {
            throw new NotImplementedException();
        }

        public Value GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Value>> GetAll()
        {
            var result = await _context.Values.ToListAsync();
            return result;
        }

        public Value Update(int id, Value value)
        {
            throw new NotImplementedException();
        }


    }
}
