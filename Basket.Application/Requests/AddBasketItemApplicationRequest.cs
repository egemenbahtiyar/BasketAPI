using System;

namespace Basket.Application.Requests
{
    public class AddBasketItemApplicationRequest
    {
        public Guid BasketId { get; set; }
        public Guid ProductId { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
    }
}