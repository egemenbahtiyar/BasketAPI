using System;
using Basket.Domain;

namespace Basket.Application.Requests
{
    public class UpdateProductApplicationRequest
    {
        public Guid ProductId { get; set; }
        public Action<Product> Product { get; set; }
    }
}