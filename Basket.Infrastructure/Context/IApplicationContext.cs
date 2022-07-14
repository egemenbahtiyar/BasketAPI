using Basket.Domain;
using MongoDB.Driver;

namespace Basket.Infrastructure.Context
{
    public interface IApplicationContext
    {
        public IMongoCollection<Product> Products { get; }
        public IMongoCollection<User> Users { get; }
        public IMongoCollection<Domain.Basket> Baskets { get; }
    }
}