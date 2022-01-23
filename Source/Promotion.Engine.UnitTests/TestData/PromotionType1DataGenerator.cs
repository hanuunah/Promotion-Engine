using PromotionEngine.Domain.Models;
using System.Collections;
using System.Collections.Generic;

namespace Promotion.Engine.UnitTests.TestData
{
    public class PromotionType1DataGenerator : IEnumerable<object[]>
    {

        private static List<PromotionType> promoTypes = new List<PromotionType>
            {
                PromotionType.Type1,
                PromotionType.Type2,
                PromotionType.Type3,
            };

        public IEnumerator<object[]> GetEnumerator()
        {
            var data = new List<object[]>();

            var skuA = new Sku("A", 50);
            var skuB = new Sku("B", 30);
            var skuC = new Sku("C", 20);
            //Scenario A
            var order = new Order(1, promoTypes);


            var itemA = new OrderItem(1, skuA, 1);
            var itemB = new OrderItem(2, skuB, 1);
            var itemC = new OrderItem(3, skuC, 1);

            order.AddItem(itemA);
            order.AddItem(itemB);
            order.AddItem(itemC);

            data.Add(new object[] { order, 50 });

            //Scenario B
            var order2 = new Order(1, promoTypes);


            var itemA2 = new OrderItem(1, skuA, 5);
            var itemB2 = new OrderItem(2, skuB, 5);
            var itemC2 = new OrderItem(3, skuC, 1);

            order2.AddItem(itemA2);
            order2.AddItem(itemB2);
            order2.AddItem(itemC2);

            data.Add(new object[] { order2, 230 });
            //Scenario C
            var order3 = new Order(1, promoTypes);
            var itemA3 = new OrderItem(1, skuA, 3);
            var itemB3 = new OrderItem(2, skuB, 5);
            var itemC3 = new OrderItem(3, skuC, 1);
            var itemD3 = new OrderItem(4, skuC, 1);

            order3.AddItem(itemA3);
            order3.AddItem(itemB3);
            order3.AddItem(itemC3);
            order3.AddItem(itemD3);
            data.Add(new object[] { order3, 130 });

            return data.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    }
}
