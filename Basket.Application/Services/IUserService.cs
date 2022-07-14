using System.Threading;
using System.Threading.Tasks;
using Basket.Application.Requests;
using Basket.Domain;

namespace Basket.Application.Services
{
    public interface IUserService
    {
        Task CreateUser(CancellationToken cancellationToken);
        Task<User> SearchUser(SearchUserApplicationRequest request, CancellationToken cancellationToken);
    }
}