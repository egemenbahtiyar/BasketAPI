using System;
using Basket.Domain.Core;

namespace Basket.Domain
{
    public class Product : Entity, IAggregateRoot
    {
        private Product(string productName, double price, int quantity)
        {
            ProductName = productName;
            Price = price;
            Quantity = quantity;
        }

        public static Product CreateProduct(string productName, double price, int quantity)
        {
            return new Product(productName, price, quantity);
        }


        public Product UpdateProduct(string productName, double price, int quantity, Guid uniqueId)
        {
            ProductName = productName;
            Price = price;
            Quantity = quantity;
            UniqueId = uniqueId;
            return this;
        }

        public string ProductName { get; private set; }
        public double Price { get; private set; }
        public int Quantity { get; private set; }
    }
}