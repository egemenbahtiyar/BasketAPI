using System.Threading;
using System.Threading.Tasks;
using Basket.Application.Requests;
using Basket.Domain;
using Basket.Domain.Contracts;

namespace Basket.Application.Services
{
    public class UserService:IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task CreateUser(CancellationToken cancellationToken)
        {
            await _userRepository.CreateUser(cancellationToken);
        }

        public async Task<User> SearchUser(SearchUserApplicationRequest request, CancellationToken cancellationToken)
        {
            return await _userRepository.SearchUser(request.UserId, cancellationToken);
        }
    }
}