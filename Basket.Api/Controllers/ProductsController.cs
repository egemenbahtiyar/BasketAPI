using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Basket.Api.Extensions;
using Basket.Application.Requests;
using Basket.Application.Services;
using Basket.Definition.Request;
using Basket.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Basket.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        [Route("createProduct")]
        public async Task<IActionResult> CreateProduct(CreateProductApiRequest request, CancellationToken cancellationToken)
        {
           await _productService.CreateProduct(request.ToApplicationRequest(), cancellationToken);

           return Ok();
        }

        [HttpDelete]
        [Route("deleteProduct")]
        public async Task<IActionResult> DeleteProduct(DeleteProductApiRequest request,
            CancellationToken cancellationToken)
        {
            await _productService.DeleteProduct(request.ToApplicationRequest(), cancellationToken);
            
            return Ok();
        }

        [HttpGet]
        [Route("searchProducts")]
        public async Task<IActionResult> SearchProducts(CancellationToken cancellationToken)
        {
            var products = await _productService.SearchProducts(cancellationToken);
            
            return Ok(products);
        }

        [HttpGet]
        [Route("searchProduct/{productId}")]
        public async Task<IActionResult> SearchProduct(Guid productId,
            CancellationToken cancellationToken)
        {
            var product = await _productService.SearchProduct(new SearchProductApplicationRequest()
            {
                ProductId = productId
            }, cancellationToken);
            
            return Ok(product);
        }
        [HttpPut]
        [Route("updateProduct")]
        public async Task<IActionResult> UpdateProduct(UpdateProductApiRequest request, CancellationToken cancellationToken)
        {
            await _productService.UpdateProduct(request.ToApplicationRequest(), cancellationToken);
            
            return Ok();
        }
    }
}