using Promotion.Engine.Domain.Models;
using System.Collections.Generic;

namespace Sales.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var promoTypes = new List<PromotionType>
            {
                PromotionType.Type1,
                PromotionType.Type2,
                PromotionType.Type3,
            };

            var skuA = new Sku("A", 50);
            var skuB = new Sku("B", 30);
            var skuC = new Sku("C", 20);
            var itemA = new OrderItem(1, skuA, 5);
            var itemB = new OrderItem(2, skuB, 5);
            var itemC = new OrderItem(3, skuC, 1);
            var order = new Order(1, promoTypes);

            order.AddItem(itemA);
            order.AddItem(itemB);
            order.AddItem(itemC);

            var promoEngine = new PromotionEngine(new PromotionProvider());
            promoEngine.CalculateTotal(order);
        }
    }
}
