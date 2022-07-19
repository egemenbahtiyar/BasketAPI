using System;
using Basket.Domain;

namespace Basket.Application.Requests
{
    public class UpdateProductApplicationRequest
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
    }
}