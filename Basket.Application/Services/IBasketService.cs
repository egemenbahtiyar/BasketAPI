using System.Threading;
using System.Threading.Tasks;
using Basket.Application.Requests;

namespace Basket.Application.Services
{
    public interface IBasketService
    {
        Task CreateBasket(CreateBasketApplicationRequest request, CancellationToken cancellationToken);
        Task ClearBasket(ClearBasketApplicationRequest request,CancellationToken cancellationToken);
        Task UpdateBasketItem(UpdateBasketItemApplicationRequest request, CancellationToken cancellationToken);
        Task AddBasketItem(AddBasketItemApplicationRequest request, CancellationToken cancellationToken);
        Task RemoveBasketItem(RemoveBasketItemApplicationRequest request, CancellationToken cancellationToken);
        Task<Domain.Basket> GetBasket(GetBasketApplicationRequest request, CancellationToken cancellationToken);
    }
}