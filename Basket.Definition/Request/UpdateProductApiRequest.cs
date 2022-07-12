using System;
using Basket.Domain;

namespace Basket.Definition.Request
{
    public class UpdateProductApiRequest
    {
        public Guid ProductId { get; set; }
        public Action<Product> Product { get; set; }
    }
}