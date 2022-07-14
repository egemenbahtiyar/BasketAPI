using System;
using System.Threading;
using System.Threading.Tasks;
using Basket.Domain;
using Basket.Domain.Contracts;
using Basket.Infrastructure.Context;
using MongoDB.Driver;

namespace Basket.Infrastructure.Repositories
{
    public class UserRepository:IUserRepository
    {
        private readonly IApplicationContext _applicationContext;

        public UserRepository(IApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public async Task CreateUser(CancellationToken cancellationToken)
        {
            await _applicationContext.Users.InsertOneAsync(User.CreateUser(),
                new InsertOneOptions(), cancellationToken);
        }
        
        public async Task<User> SearchUser(Guid userId, CancellationToken cancellationToken)
        {
            var filter = Builders<User>.Filter.Eq(x => x.UserId, userId);

            return await _applicationContext.Users.FindSync(filter, new FindOptions<User>(), cancellationToken)
                .FirstOrDefaultAsync(cancellationToken);
        }
    }
}