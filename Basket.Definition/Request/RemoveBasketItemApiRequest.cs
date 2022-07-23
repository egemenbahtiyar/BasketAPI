using System;

namespace Basket.Definition.Request
{
    public class RemoveBasketItemApiRequest
    {
        public Guid BasketId { get; set; }
        public Guid ProductId { get; set; }
    }
}