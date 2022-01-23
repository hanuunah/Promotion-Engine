using Promotion.Engine.Domain.Models;
using System.Collections.Generic;

namespace Promotion.Engine.UnitTests.TestData
{
    public class PromotionEngineDataGenerator
    {

        public static IEnumerable<object[]> GetData()
        {
            var data = new List<object[]>();


            PrepareScenarioA(data);
            PrepareScenarioB(data);
            PrepareScenarioC(data);

            return data;
        }

        private static void PrepareScenarioC(List<object[]> data)
        {
            var order3 = PromotionDataGenerator.GetScenarioCOrder();
            data.Add(new object[] { order3, 280 });
        }

        private static void PrepareScenarioB(List<object[]> data)
        {
            var order2 = PromotionDataGenerator.GetScenarioBOrder();

            data.Add(new object[] { order2, 370 });
        }

        private static void PrepareScenarioA(List<object[]> data)
        {
            Order order = PromotionDataGenerator.GetScenarioAOrder();

            data.Add(new object[] { order, 100 });
        }

    }
}
