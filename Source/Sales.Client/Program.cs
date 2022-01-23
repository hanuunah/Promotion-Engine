using Promotion.Engine.Domain.Models;
using Promotion.Engine.UnitTests.TestData;
using System;

namespace Sales.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var promoEngine = new PromotionEngine(new PromotionProvider());

            var orderA = PromotionDataGenerator.GetScenarioAOrder();
            promoEngine.CalculateTotal(orderA);
            Console.WriteLine($"Scenario A, Total {orderA.Total}");


            var orderB = PromotionDataGenerator.GetScenarioBOrder();
            promoEngine.CalculateTotal(orderB);
            Console.WriteLine($"Scenario B, Total {orderB.Total}");


            var orderC = PromotionDataGenerator.GetScenarioCOrder();
            promoEngine.CalculateTotal(orderC);
            Console.WriteLine($"Scenario C, Total {orderC.Total}");

            Console.ReadLine();
        }


    }
}
