using System;

namespace CondoManager.Domain.Core.Interfaces
{
    public interface IRepository<T> where T : IEntity
    {
        T Find(Guid guid);
        void Add(T data);
        void Update(T data);
        void Delete(T data);
        void Save();
    }
}
