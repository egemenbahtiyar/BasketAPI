using System;
using System.Collections.Generic;
using System.Threading;
using Basket.Domain;
using Basket.Domain.Contracts;
using Basket.Infrastructure.Context;
using Basket.Infrastructure.Repositories;
using Xunit;

namespace Basket.DomainTest
{
    public class UnitTest2
    {
        private readonly IProductRepository _productRepository;
        public UnitTest2(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        [Fact]  
        public async void GetProductById()
        {
            var cT = new CancellationToken();
            var result = await _productRepository.SearchProducts(cT);
            Assert.Equal(3,result.Count);
        }  
    }
}