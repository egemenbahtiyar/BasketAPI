using System;

namespace Basket.Definition.Request
{
    public class AddBasketItemApiRequest
    {
        public Guid BasketId { get; set; }
        public Guid ProductId { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
    }
}