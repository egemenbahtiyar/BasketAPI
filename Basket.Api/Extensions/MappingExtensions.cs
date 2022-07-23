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
        public static AddBasketItemApplicationRequest ToApplicationRequest(this AddBasketItemApiRequest request)
        {
            return new AddBasketItemApplicationRequest()
            {
                BasketId = request.BasketId,
                ProductId = request.ProductId,
                Price = request.Price,
                Quantity = request.Quantity
            };
        }
        public static ClearBasketApplicationRequest ToApplicationRequest(this ClearBasketApiRequest request)
        {
            return new ClearBasketApplicationRequest()
            {
                BasketId = request.BasketId
            };
        }
        public static CreateBasketApplicationRequest ToApplicationRequest(this CreateBasketApiRequest request)
        {
            return new CreateBasketApplicationRequest()
            {
                UserId = request.UserId
            };
        }
        public static GetBasketApplicationRequest ToApplicationRequest(this GetBasketApiRequest request)
        {
            return new GetBasketApplicationRequest()
            {
                BasketId = request.BasketId
            };
        }
        public static RemoveBasketItemApplicationRequest ToApplicationRequest(this RemoveBasketItemApiRequest request)
        {
            return new RemoveBasketItemApplicationRequest()
            {
                BasketId = request.BasketId,
                ProductId = request.ProductId
            };
        }
        public static UpdateBasketItemApplicationRequest ToApplicationRequest(this UpdateBasketItemApiRequest request)
        {
            return new UpdateBasketItemApplicationRequest()
            {
                BasketId = request.BasketId,
                ProductId = request.ProductId,
                Quantity = request.Quantity
            };
        }
    }
}