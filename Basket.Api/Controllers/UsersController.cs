using System.Threading;
using System.Threading.Tasks;
using Basket.Api.Extensions;
using Basket.Application.Services;
using Basket.Definition.Request;
using Basket.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Basket.Api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class UsersController:ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CancellationToken cancellationToken)
        {
            await _userService.CreateUser(cancellationToken);
            return Ok();
        }

        [HttpGet]
        public async Task<User> SearchUser([FromQuery]SearchUserApiRequest request, CancellationToken cancellationToken)
        {
            return await _userService.SearchUser(request.ToApplicationRequest(), cancellationToken);
        }
    }
}