using System;
using Basket.Domain.Core;

namespace Basket.Domain
{
    public class BasketItem : ValueObject
    {
        private BasketItem(Guid productId, double price, int quantity)
        {
            ProductId = productId;
            Price = price;
            Quantity = quantity;
        }

        internal static BasketItem CreateBasketItem(Guid productId, double price, int quantity)
        {
            return new BasketItem(productId, price, quantity);
        }

        public void UpdateBasketItem(int quantity)
        {
            Quantity = quantity;
        }

        public Guid ProductId { get; private set; }
        public double Price { get; private set; }
        public int Quantity { get; private set; }
    }
}