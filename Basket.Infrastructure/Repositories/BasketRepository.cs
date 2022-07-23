using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Basket.Domain;
using Basket.Domain.Contracts;
using Basket.Infrastructure.Context;
using MongoDB.Driver;

namespace Basket.Infrastructure.Repositories
{
    public class BasketRepository:IBasketRepository
    {
        private readonly IApplicationContext _applicationContext;

        public BasketRepository(IApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public async Task CreateBasket(Guid userId, CancellationToken cancellationToken)
        {
            var user = await _applicationContext.Users.FindSync(x => x.UserId == userId)
                .SingleOrDefaultAsync(cancellationToken);
            await _applicationContext.Baskets.InsertOneAsync(Domain.Basket.CreateBasket(user),
                new InsertOneOptions(), cancellationToken);
        }

        public async Task ClearBasket(Guid basketId, CancellationToken cancellationToken)
        {
            var basket = await GetBasket(basketId, cancellationToken);
            var newBasket = basket.ClearBasket();
            await _applicationContext.Baskets.ReplaceOneAsync(x => x.UniqueId == basketId, newBasket,
                new ReplaceOptions()
                {
                    IsUpsert = false
                }, cancellationToken);
        }

        public async Task UpdateBasketItem(Guid basketId, Guid productId, int quantity, CancellationToken cancellationToken)
        {
            var basket = await GetBasket(basketId, cancellationToken);
            var newBasket = basket.UpdateBasketItem(productId,quantity);
            await _applicationContext.Baskets.ReplaceOneAsync(x => x.UniqueId == basketId, newBasket,
                new ReplaceOptions()
                {
                    IsUpsert = false
                }, cancellationToken);
            
        }

        public async Task AddBasketItem(Guid basketId, Guid productId, double price, int quantity, CancellationToken cancellationToken)
        {
            var basket = await GetBasket(basketId, cancellationToken);
            var newBasket = basket.AddBasketItem(productId, price, quantity);
            await _applicationContext.Baskets.ReplaceOneAsync(x => x.UniqueId == basketId, newBasket,
                new ReplaceOptions()
                {
                    IsUpsert = false
                }, cancellationToken);
        }

        public async Task RemoveBasketItem(Guid basketId, Guid productId, CancellationToken cancellationToken)
        {
            var basket = await GetBasket(basketId, cancellationToken);
            var newBasket = basket.RemoveBasketItem(productId);
            await _applicationContext.Baskets.ReplaceOneAsync(x => x.UniqueId == basketId, newBasket,
                new ReplaceOptions()
                {
                    IsUpsert = false
                }, cancellationToken);
        }

        public async Task<Domain.Basket> GetBasket(Guid basketId, CancellationToken cancellationToken)
        {
            var filter = Builders<Domain.Basket>.Filter.Eq(x => x.UniqueId, basketId);
            return await _applicationContext.Baskets.FindSync(filter, new FindOptions<Domain.Basket>(), cancellationToken)
                .FirstOrDefaultAsync(cancellationToken);
        }
    }
}