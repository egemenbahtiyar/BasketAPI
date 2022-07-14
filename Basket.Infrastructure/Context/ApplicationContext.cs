using Basket.Domain;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Basket.Infrastructure.Context
{
    public class ApplicationContext: IApplicationContext
    {

        private readonly IMongoDatabase _database = null;

        public ApplicationContext(IOptions<MongoDbSettings> mongoDbSettings)
        {
            var client = new MongoClient(mongoDbSettings.Value.ConnectionString);
            _database = client.GetDatabase(mongoDbSettings.Value.DataBase);
        }

        public IMongoCollection<Product> Products => _database.GetCollection<Product>("Products");
        public IMongoCollection<Domain.Basket> Baskets => _database.GetCollection<Domain.Basket>("Baskets");
        public IMongoCollection<User> Users => _database.GetCollection<User>("Users");
  
    }
}