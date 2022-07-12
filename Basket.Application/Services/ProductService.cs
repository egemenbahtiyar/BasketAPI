using System.Threading;
using System.Threading.Tasks;
using Basket.Application.Requests;
using Basket.Domain.Contracts;

namespace Basket.Application.Services
{
    public class ProductService: IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task CreateProduct(CreateProductApplicationRequest request, CancellationToken cancellationToken)
        {
            await _productRepository.CreateProduct(request.ProductName, request.Price, request.Quantity, cancellationToken);
        }
    }
}