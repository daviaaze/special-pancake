using CondoManager.Domain.Core.Interfaces;
using System;

namespace CondoManager.Domain.Core
{
    public class Entity : IEntity
    {
        public Guid Id { get; protected set; }
    }
}
