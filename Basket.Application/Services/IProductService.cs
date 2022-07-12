using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Basket.Application.Requests;
using Basket.Definition.Request;
using Basket.Domain;

namespace Basket.Application.Services
{
    public interface IProductService
    {
        Task CreateProduct(CreateProductApplicationRequest request, CancellationToken cancellationToken);
        Task UpdateProduct(UpdateProductApplicationRequest request, CancellationToken cancellationToken);
        Task DeleteProduct(DeleteProductApplicationRequest request, CancellationToken cancellationToken);
        Task<List<Product>> SearchProducts(CancellationToken cancellationToken);
        Task<Product> SearchProduct(SearchProductApplicationRequest request, CancellationToken cancellationToken);

    }
}