using System;
using Basket.Domain.Core;

namespace Basket.Domain
{
    public class User: ValueObject
    {
        public Guid UserId { get; set; }
        
    }
}