using System;

namespace Basket.Application.Requests
{
    public class UpdateBasketItemApplicationRequest
    {
        public Guid BasketId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}