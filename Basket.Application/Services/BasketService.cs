using System.Threading;
using System.Threading.Tasks;
using Basket.Application.Requests;
using Basket.Domain.Contracts;

namespace Basket.Application.Services
{
    public class BasketService:IBasketService
    {
        private readonly IBasketRepository _basketRepository;

        public BasketService(IBasketRepository basketRepository)
        {
            _basketRepository = basketRepository;
        }

        public async Task CreateBasket(CreateBasketApplicationRequest request, CancellationToken cancellationToken)
        {
            await _basketRepository.CreateBasket(request.UserId, cancellationToken);
        }

        public async Task ClearBasket(ClearBasketApplicationRequest request, CancellationToken cancellationToken)
        {
            await _basketRepository.ClearBasket(request.BasketId, cancellationToken);
        }

        public async Task UpdateBasketItem(UpdateBasketItemApplicationRequest request, CancellationToken cancellationToken)
        {
            await _basketRepository.UpdateBasketItem(request.BasketId, request.ProductId, request.Quantity,
                cancellationToken);
        }

        public async Task AddBasketItem(AddBasketItemApplicationRequest request, CancellationToken cancellationToken)
        {
            await _basketRepository.AddBasketItem(request.BasketId,request.ProductId,request.Price,request.Quantity,cancellationToken);
        }

        public async Task RemoveBasketItem(RemoveBasketItemApplicationRequest request, CancellationToken cancellationToken)
        {
            await _basketRepository.RemoveBasketItem(request.BasketId, request.ProductId, cancellationToken);
        }

        public async Task<Domain.Basket> GetBasket(GetBasketApplicationRequest request, CancellationToken cancellationToken)
        {
            return await _basketRepository.GetBasket(request.BasketId, cancellationToken);
        }
    }
}