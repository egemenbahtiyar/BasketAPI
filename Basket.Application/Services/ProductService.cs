using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Basket.Application.Requests;
using Basket.Domain;
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

        public async Task UpdateProduct(UpdateProductApplicationRequest request, CancellationToken cancellationToken)
        {
            await _productRepository.UpdateProduct(request.ProductId, request.Product, cancellationToken);
        }

        public async Task DeleteProduct(DeleteProductApplicationRequest request, CancellationToken cancellationToken)
        {
            await _productRepository.DeleteProduct(request.ProductId, cancellationToken);
        }

        public async Task<List<Product>> SearchProducts(CancellationToken cancellationToken)
        {
            return await _productRepository.SearchProducts(cancellationToken);
        }

        public async Task<Product> SearchProduct(SearchProductApplicationRequest request, CancellationToken cancellationToken)
        {
            var product =  await _productRepository.SearchProduct(request.ProductId, cancellationToken);

            return product;
        }
    }
}