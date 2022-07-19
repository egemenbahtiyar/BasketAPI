using System;
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
        public static DeleteProductApplicationRequest ToApplicationRequest(this DeleteProductApiRequest request)
        {
            return new DeleteProductApplicationRequest()
            {
                ProductId = request.ProductId
            };
        }
        
        public static UpdateProductApplicationRequest ToApplicationRequest(this UpdateProductApiRequest request)
        {
            return new UpdateProductApplicationRequest()
            {
                ProductId = request.ProductId,
                ProductName = request.ProductName,
                Quantity = request.Quantity,
                Price = request.Price
            };
        }
        public static SearchProductApplicationRequest ToApplicationRequest(this SearchProductApiRequest request)
        {
            return new SearchProductApplicationRequest()
            {
                ProductId = request.ProductId
            };
        }
        public static SearchUserApplicationRequest ToApplicationRequest(this SearchUserApiRequest request)
        {
            return new SearchUserApplicationRequest()
            {
                UserId = request.UserId
            };
        }
    }
}