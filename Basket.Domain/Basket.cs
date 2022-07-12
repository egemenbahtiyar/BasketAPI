using System;
using System.Collections.Generic;
using System.Linq;
using Basket.Domain.Core;

namespace Basket.Domain
{
    public class Basket : Entity, IAggregateRoot
    {
        protected Basket(User user)
        {
            User = user;
        }

        public static Basket CreateBasket(User user)
        {
            return new Basket(user);
        }

        public List<BasketItem> BasketItems { get; private set; }

        public Basket AddBasketItem(Guid productId, double price, int quantity)
        {
            BasketItems ??= new List<BasketItem>();

            BasketItems.Add(BasketItem.CreateBasketItem(productId,price, quantity));

            return this;
        }

        public void ClearBasket()
        {
            BasketItems.Clear();
        }

        public Basket RemoveBasketItem(Guid productId)
        {
            var basketItem = BasketItems.FirstOrDefault(x => x.ProductId == productId);

            if (basketItem is null)
            {
                throw new DomainException($"{productId} could not found!");
            }

            BasketItems.Remove(basketItem);

            return this;
        }


        public Basket UpdateBasketItem(Guid productId, int quantity)
        {
            var basketItem = BasketItems.FirstOrDefault(x => x.ProductId == productId);

            if (basketItem is null)
            {
                throw new DomainException($"{productId} could not found!");
            }
            basketItem.UpdateBasketItem(quantity);

            return this;
        }

        public Basket UpdateUser(User user)
        {
            User = user;
            return this;
        }
        public User User { get; private set; }
    }
}