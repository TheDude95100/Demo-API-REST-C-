using TwinSim.Domain.Models;

namespace TwinSim.Domain.Interfaces
{
    public interface ITwinService
    {
        IEnumerable<TwinObject> GetAll();
        TwinObject? GetById(Guid id);
        TwinObject Create(TwinObject obj);
        bool Update(Guid id, TwinObject obj);
        bool Delete(Guid id);
    }
}