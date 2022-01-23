using NFluent;
using Promotion.Engine.Domain.Interfaces;
using Promotion.Engine.Domain.Models;
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

        [Fact]
        public void CalculateTotal_ValidPromotionAppliedItems_CalcullateTotal()
        {
            var skuA = new Sku("A", 50);
            var itemA = new OrderItem(1, skuA, 5)
            {
                IsPromotionAplied = true
            };

            var skuB = new Sku("B", 30);
            var itemB = new OrderItem(1, skuB, 5)
            {
                IsPromotionAplied = true
            };

            _target.AddItem(itemA);
            _target.AddItem(itemB);

            _target.CalculateTotal();

            Check.That(_target.Total).Equals(0);
        }


        [Fact]
        public void CalculateTotal_ValidNotApplicablePromoItems_CalcullateTotal()
        {
            var skuA = new Sku("A", 50);
            var itemA = new OrderItem(1, skuA, 5);
           

            var skuB = new Sku("B", 30);
            var itemB = new OrderItem(1, skuB, 5);

            _target.AddItem(itemA);
            _target.AddItem(itemB);

            _target.CalculateTotal();

            Check.That(_target.Total).Equals(400);
        }

        [Fact]
        public void CalculateTotal_ValidPromoAndNonPromoItems_CalcullateTotal()
        {
            var skuA = new Sku("A", 50);
            var itemA = new OrderItem(1, skuA, 5)
            {
                IsPromotionAplied = true
            };


            var skuB = new Sku("B", 30);
            var itemB = new OrderItem(1, skuB, 5);

            _target.AddItem(itemA);
            _target.AddItem(itemB);

            _target.CalculateTotal();

            Check.That(_target.Total).Equals(150);
        }

    }
}
