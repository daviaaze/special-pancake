using System;

namespace CondoManager.Domain.Core.Interfaces
{
    public interface IRepository<T> where T : IEntity
    {
        public T Find(Guid guid);
        public void Add(T data);
        public void Update(T data);
        public void Delete(T data);
    }
}
