using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Basket.Domain.Contracts
{
    public interface IProductRepository
    {
        Task CreateProduct(string productName, double price, int quantity, CancellationToken cancellationToken);
        Task UpdateProduct(Guid productId, Action<Product> product, CancellationToken cancellationToken);
        Task DeleteProduct(Guid productId, CancellationToken cancellationToken);
        Task<List<Product>> SearchProducts(CancellationToken cancellationToken);
        Task<Product> SearchProduct(Guid productId, CancellationToken cancellationToken);
    }
}