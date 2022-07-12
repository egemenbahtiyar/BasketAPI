using System;

namespace Basket.Domain.Core
{
    public class Entity
    {
        public Guid UniqueId { get; }

        public Entity()
        {
            UniqueId = Guid.NewGuid();
        }
    }
}