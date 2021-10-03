using System;

namespace Domain.Aggregates
{
    public abstract class Entity
    {
        public long Id { get; protected set; }
    }
}
