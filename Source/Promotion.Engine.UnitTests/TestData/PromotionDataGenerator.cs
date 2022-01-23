using PromotionEngine.Domain.Models;
using System.Collections.Generic;

namespace Promotion.Engine.UnitTests.TestData
{
    public class PromotionDataGenerator
    {
        private static readonly List<PromotionType> _promoTypes = new List<PromotionType>
            {
                PromotionType.Type1,
                PromotionType.Type2,
                PromotionType.Type3,
            };

        private static readonly Sku _skuA = new Sku("A", 50);
        private static readonly Sku _skuB = new Sku("B", 30);
        private static readonly Sku _skuC = new Sku("C", 20);
        private static readonly Sku _skuD = new Sku("D", 30);

        public static Order GetScenarioAOrder()
        {
            var order = new Order(1, _promoTypes);


            var itemA = new OrderItem(1, _skuA, 1);
            var itemB = new OrderItem(2, _skuB, 1);
            var itemC = new OrderItem(3, _skuC, 1);

            order.AddItem(itemA);
            order.AddItem(itemB);
            order.AddItem(itemC);
            return order;
        }

        public static Order GetScenarioCOrder()
        {
            var order3 = new Order(1, _promoTypes);
            var itemA3 = new OrderItem(1, _skuA, 3);
            var itemB3 = new OrderItem(2, _skuB, 5);
            var itemC3 = new OrderItem(3, _skuC, 1);
            var itemD3 = new OrderItem(4, _skuD, 1);

            order3.AddItem(itemA3);
            order3.AddItem(itemB3);
            order3.AddItem(itemC3);
            order3.AddItem(itemD3);
            return order3;
        }

        public static Order GetScnearioBOrder()
        {
            var order2 = new Order(1, _promoTypes);
            var itemA2 = new OrderItem(1, _skuA, 5);
            var itemB2 = new OrderItem(2, _skuB, 5);
            var itemC2 = new OrderItem(3, _skuC, 1);

            order2.AddItem(itemA2);
            order2.AddItem(itemB2);
            order2.AddItem(itemC2);
            return order2;
        }
    }
}