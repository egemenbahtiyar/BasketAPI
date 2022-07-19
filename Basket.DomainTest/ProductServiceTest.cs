using System.Threading;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.AutoMoq;
using Basket.Application.Requests;
using Basket.Application.Services;
using Basket.Domain.Contracts;
using Moq;
using Xunit;

namespace Basket.DomainTest
{
    public class ProductServiceTest
    {
        private Mock<IProductRepository> _productRepository;
        private IFixture _fixture;
        private ProductService _productService;

        public ProductServiceTest()
        {
            _fixture = new Fixture().Customize(new AutoMoqCustomization());
            _productRepository = _fixture.Freeze<Mock<IProductRepository>>();
            _productService = _fixture.Create<ProductService>();
        }

        [Fact]
        public async Task Should_Have_Created_Product()
        {
            // Arrange

            var creatProductApplicationRequest = new CreateProductApplicationRequest()
            {
                Price = 10,
                Quantity = 1,
                ProductName = "Kek"
            };
            _productRepository.Setup(x => x.CreateProduct(It.IsAny<string>(), It.IsAny<double>(),
                It.IsAny<int>(), It.IsAny<CancellationToken>()));

            // Act

            await _productService.CreateProduct(creatProductApplicationRequest, It.IsAny<CancellationToken>());

            // Assert

            _productRepository.Verify(x=>x.CreateProduct(It.IsAny<string>(), It.IsAny<double>(),
                It.IsAny<int>(), It.IsAny<CancellationToken>()),Times.Once);
        }
        [Fact]
        public async Task Should_Have_Return_All_Products()
        {
            // Arrange
            
            _productRepository.Setup(x=>x.SearchProducts(It.IsAny<CancellationToken>()));

            // Act

            await _productService.SearchProducts(It.IsAny<CancellationToken>());

            // Assert

            _productRepository.Verify(x=>x.SearchProducts(It.IsAny<CancellationToken>()),Times.Once);
        }
    }
}