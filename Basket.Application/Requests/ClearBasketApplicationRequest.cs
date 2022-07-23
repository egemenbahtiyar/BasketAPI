using System;

namespace Basket.Application.Requests
{
    public class ClearBasketApplicationRequest
    {
        public Guid BasketId { get; set; }
    }
}