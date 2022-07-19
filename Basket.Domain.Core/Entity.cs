using System;
using MongoDB.Bson.Serialization.Attributes;

namespace Basket.Domain.Core
{
    public class Entity
    {
        [BsonId]
        public Guid UniqueId { get; set; }

        public Entity()
        {
            UniqueId = Guid.NewGuid();
        }
    }
}