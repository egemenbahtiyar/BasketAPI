using System;
using System.Collections.Generic;
using System.Threading;
using Basket.Api.Controllers;
using Basket.Application.Requests;
using Basket.Application.Services;
using Basket.Definition.Request;
using Basket.Domain;
using Basket.Domain.Contracts;
using Moq;
using Xunit;

namespace Basket.DomainTest
{
    public class UnitTest1
    {
        //It.IsAny<int>() Opsiyonel parameter
        //Verify ile kaç kez çalıştığına bakabilirsin
        //mathematics.Verify(x => x.Sum(1, 2), Times.AtLeast(2));
        public Mock<IProductRepository> mock = new Mock<IProductRepository>();
        [Fact]  
        public async void GetProductById() //
        {
            var request = new SearchProductApplicationRequest()
            {
                ProductId = new Guid("0CA31F19-B050-4965-95E8-3B58A3004C06")
            };
            var expectedProduct = Product.CreateProduct("item2", 57.0, 4);
            mock.Setup(p => p.SearchProduct(It.IsAny<Guid>(),It.IsAny<CancellationToken>())).ReturnsAsync(expectedProduct);  
            ProductService pro = new ProductService(mock.Object);
            var result = await pro.SearchProduct(request, It.IsAny<CancellationToken>());  
            Assert.Equal(expectedProduct, result);  
        }  
        [Fact]  
        public async void GetAllProducts()  
        {  
            var cT = new CancellationToken();
            var expectedProductList = new List<Product>();
            var p1 = Product.CreateProduct("item2", 57.0, 4);
            var p2 = Product.CreateProduct("urun-1", 98.0, 4);
            var p3 = Product.CreateProduct("urun-56", 92.0, 5);
            expectedProductList.Add(p1);
            expectedProductList.Add(p2);
            expectedProductList.Add(p3);
            mock.Setup(p => p.SearchProducts(cT)).ReturnsAsync(expectedProductList);
            ProductService pro = new ProductService(mock.Object);
            var result = await pro.SearchProducts(cT);  
            Assert.Equal(expectedProductList, result); 
        }
    }
}