using Basket.Application.Requests;
using Basket.Definition.Request;

namespace Basket.Api.Extensions
{
    public static class MappingExtensions
    {
        public static CreateProductApplicationRequest ToApplicationRequest(this CreateProductApiRequest request)
        {
            return new CreateProductApplicationRequest()
            {
                Price = request.Price,
                ProductName = request.ProductName,
                Quantity = request.Quantity,
            };
        }
    }
}