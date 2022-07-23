using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Basket.Domain.Contracts
{
    public interface IBasketRepository
    {
        Task CreateBasket(Guid userId, CancellationToken cancellationToken);
        Task ClearBasket(Guid basketId,CancellationToken cancellationToken);
        Task UpdateBasketItem(Guid basketId,Guid productId, int quantity, CancellationToken cancellationToken);
        Task AddBasketItem(Guid basketId,Guid productId, double price, int quantity, CancellationToken cancellationToken);
        Task RemoveBasketItem(Guid basketId,Guid productId, CancellationToken cancellationToken);
        Task<Basket> GetBasket(Guid basketId, CancellationToken cancellationToken);
    }
}