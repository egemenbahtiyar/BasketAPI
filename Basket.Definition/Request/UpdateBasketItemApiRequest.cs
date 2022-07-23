using System;

namespace Basket.Definition.Request
{
    public class UpdateBasketItemApiRequest
    {
        public Guid BasketId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}