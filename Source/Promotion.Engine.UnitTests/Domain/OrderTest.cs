
using NFluent;
using PromotionEngine.Domain.Interfaces;
using PromotionEngine.Domain.Models;
using System.Collections.Generic;
using Xunit;

namespace Promotion.Engine.UnitTests.Domain
{
    public class OrderTest
    {

        private readonly IOrder _target;
        public OrderTest()
        {
            var promoTypes = new List<PromotionType>
            {
                PromotionType.Type1,
                PromotionType.Type2,
                PromotionType.Type3,
            };

            _target = new Order(1, promoTypes);
        }

        [Fact]
        public void AddItem_ValidItem_AddItemToOrder()
        {
            var skuA = new Sku("A", 50);
            var itemA = new OrderItem(1, skuA, 5);
            _target.AddItem(itemA);

            Check.That(_target.Items).HasSize(1);
        }

        [Fact]
        public void AddItem_InvalidValidItem_FailedToAddItemToOrder()
        {
            _target.AddItem(null);

            Check.That(_target.Items).HasSize(0);
        }

    }
}
