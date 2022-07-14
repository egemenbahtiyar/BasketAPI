using System;
using System.Threading;
using System.Threading.Tasks;

namespace Basket.Domain.Contracts
{
    public interface IUserRepository
    {
        Task CreateUser(CancellationToken cancellationToken);
        Task<User> SearchUser(Guid userId, CancellationToken cancellationToken);
    }
}