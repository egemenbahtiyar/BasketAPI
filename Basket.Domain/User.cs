using System;
using Basket.Domain.Core;
using MongoDB.Bson.Serialization.Attributes;

namespace Basket.Domain
{
    public class User: ValueObject
    {
        [BsonId]
        public Guid UserId { get; set; }
        
        private User(Guid userId)
        {
            UserId = userId;
        }

        public static User CreateUser()
        {
            return new User(new Guid());
        }
        
    }
}