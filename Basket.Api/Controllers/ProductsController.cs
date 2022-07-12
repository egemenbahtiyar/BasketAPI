using System.Threading;
using System.Threading.Tasks;
using Basket.Api.Extensions;
using Basket.Application.Services;
using Basket.Definition.Request;
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
    }
}