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
    public class ProductRepository : IProductRepository
    {
        private readonly IApplicationContext _applicationContext;

        public ProductRepository(IApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public async Task CreateProduct(string productName, double price, int quantity,
            CancellationToken cancellationToken)
        {
            await _applicationContext.Products.InsertOneAsync(Product.CreateProduct(productName, price, quantity),
                new InsertOneOptions(), cancellationToken);
        }

        public async Task UpdateProduct(Guid productId, Action<Product> product, CancellationToken cancellationToken)
        {
            var entity = await _applicationContext.Products.FindSync(x => x.UniqueId == productId)
                .SingleOrDefaultAsync(cancellationToken);

            product(entity);

            await _applicationContext.Products.ReplaceOneAsync(x => x.UniqueId == entity.UniqueId, entity,
                new ReplaceOptions()
                {
                    IsUpsert = false
                }, cancellationToken);
        }

        public async Task DeleteProduct(Guid productId, CancellationToken cancellationToken)
        {
            await _applicationContext.Products.DeleteOneAsync(x => x.UniqueId == productId, cancellationToken);
        }

        public async Task<List<Product>> SearchProducts(CancellationToken cancellationToken)
        {
            return await _applicationContext.Products.FindSync(x => true).ToListAsync(cancellationToken);
        }

        public async Task<Product> SearchProduct(Guid productId, CancellationToken cancellationToken)
        {
            var filter = Builders<Product>.Filter.Eq(x => x.UniqueId, productId);

            return await _applicationContext.Products.FindSync(filter, new FindOptions<Product>(), cancellationToken)
                .FirstOrDefaultAsync(cancellationToken);
        }
    }
}