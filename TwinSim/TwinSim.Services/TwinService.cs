using TwinSim.Domain.Interfaces;
using TwinSim.Domain.Models;

namespace TwinSim.Services
{
    public class TwinService : ITwinService
    {
        private readonly Dictionary<Guid, TwinObject> _store = new();

        public IEnumerable<TwinObject> GetAll() => _store.Values;

        public TwinObject? GetById(Guid id) => _store.GetValueOrDefault(id);

        public TwinObject Create(TwinObject obj)
        {
            _store[obj.Id] = obj;
            return obj;
        }

        public bool Update(Guid id, TwinObject obj)
        {
            if (!_store.ContainsKey(id)) return false;
            _store[id] = new TwinObject
            {
                Id = id,
                Name = obj.Name,
                Position = obj.Position,
                Status = obj.Status,
            };
            return true;
        }

        public bool Delete(Guid id) => _store.Remove(id);
    }
    }