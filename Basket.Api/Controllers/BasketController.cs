using System;
using System.Threading;
using System.Threading.Tasks;
using Basket.Api.Extensions;
using Basket.Application.Services;
using Basket.Definition.Request;
using Basket.Domain;
using Basket.Domain.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Basket.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BasketController:ControllerBase
    {
        private readonly IBasketService _basketService;

        public BasketController(IBasketService basketService)
        {
            _basketService = basketService;
        }
        
        [HttpPost]
        [Route("createBasket")]
        public async Task<IActionResult> CreateBasket(CreateBasketApiRequest request, CancellationToken cancellationToken)
        {
            await _basketService.CreateBasket(request.ToApplicationRequest(), cancellationToken);

            return Ok();
        }
        [HttpPost]
        [Route("addBasketItem")]
        public async Task<IActionResult> AddBasketItem(AddBasketItemApiRequest request, CancellationToken cancellationToken)
        {
            await _basketService.AddBasketItem(request.ToApplicationRequest(), cancellationToken);

            return Ok();
        }
        [HttpDelete]
        [Route("removeBasketItem")]
        public async Task<IActionResult> RemoveBasketItem(RemoveBasketItemApiRequest request,
            CancellationToken cancellationToken)
        {
            await _basketService.RemoveBasketItem(request.ToApplicationRequest(), cancellationToken);
            
            return Ok();
        }
        [HttpPost]
        [Route("clearBasket")]
        public async Task<IActionResult> ClearBasket(ClearBasketApiRequest request, CancellationToken cancellationToken)
        {
            await _basketService.ClearBasket(request.ToApplicationRequest(), cancellationToken);

            return Ok();
        }
        [HttpPost]
        [Route("updateBasketItem")]
        public async Task<IActionResult> UpdateBasketItem(UpdateBasketItemApiRequest request, CancellationToken cancellationToken)
        {
            await _basketService.UpdateBasketItem(request.ToApplicationRequest(), cancellationToken);

            return Ok();
        }
        [HttpGet]
        [Route("getBasket")]
        public async Task<IActionResult> GetBasket([FromQuery]GetBasketApiRequest request, CancellationToken cancellationToken)
        {
            var basket = await _basketService.GetBasket(request.ToApplicationRequest(), cancellationToken);

            return Ok(basket);
        }
    }
}