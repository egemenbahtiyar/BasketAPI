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
    [Route("[controller]/[action]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductApiRequest request, CancellationToken cancellationToken)
        {
           await _productService.CreateProduct(request.ToApplicationRequest(), cancellationToken);

           return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(DeleteProductApiRequest request,
            CancellationToken cancellationToken)
        {
            await _productService.DeleteProduct(request.ToApplicationRequest(), cancellationToken);
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> SearchProducts(CancellationToken cancellationToken)
        {
            var products = await _productService.SearchProducts(cancellationToken);
            return Ok(products);
        }

        [HttpGet]
        public async Task<ActionResult<Product>> SearchProduct([FromQuery]SearchProductApiRequest request,
            CancellationToken cancellationToken)
        {
            var product = await _productService.SearchProduct(request.ToApplicationRequest(), cancellationToken);
            return Ok(product);
        }
    }
}