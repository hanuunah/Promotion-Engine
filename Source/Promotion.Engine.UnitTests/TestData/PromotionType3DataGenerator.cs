using Promotion.Engine.Domain.Models;
using System.Collections.Generic;

namespace Promotion.Engine.UnitTests.TestData
{
    public class PromotionType3DataGenerator
    {

        public static IEnumerable<object[]> GetDataForScenarioAandB()
        {
            var data = new List<object[]>();


            PrepareScenarioA(data);
            PrepareScenarioB(data);

            return data;
        }

        public static IEnumerable<object[]> GetDataForScenarioC()
        {
            var data = new List<object[]>();


            PrepareScenarioC(data);

            return data;
        }

        private static void PrepareScenarioC(List<object[]> data)
        {
            var order3 = PromotionDataGenerator.GetScenarioCOrder();
            data.Add(new object[] { order3, 0, 30 });
        }

        private static void PrepareScenarioB(List<object[]> data)
        {
            var order2 = PromotionDataGenerator.GetScenarioBOrder();

            data.Add(new object[] { order2, 0 });
        }

        private static void PrepareScenarioA(List<object[]> data)
        {
            Order order = PromotionDataGenerator.GetScenarioAOrder();

            data.Add(new object[] { order, 0 });
        }

    }
}
