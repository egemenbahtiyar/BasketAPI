using System;

namespace Basket.Application.Requests
{
    public class RemoveBasketItemApplicationRequest
    {
        public Guid BasketId { get; set; }
        public Guid ProductId { get; set; }
    }
}