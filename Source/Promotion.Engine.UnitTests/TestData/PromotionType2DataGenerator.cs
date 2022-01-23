using PromotionEngine.Domain.Models;
using System.Collections;
using System.Collections.Generic;

namespace Promotion.Engine.UnitTests.TestData
{
    public class PromotionType1DataGenerator : IEnumerable<object[]>
    {

        public IEnumerator<object[]> GetEnumerator()
        {
            var data = new List<object[]>();


            PrepareScenarioA(data);
            PrepareScenarioB(data);
            PrepareScenarioC(data);

            return data.GetEnumerator();
        }

        private static void PrepareScenarioC(List<object[]> data)
        {
            var order3 = PromotionDataGenerator.GetScenarioCOrder();
            data.Add(new object[] { order3, 130 });
        }

        private static void PrepareScenarioB(List<object[]> data)
        {
            var order2 = PromotionDataGenerator.GetScnearioBOrder();

            data.Add(new object[] { order2, 230 });
        }

        private static void PrepareScenarioA(List<object[]> data)
        {
            Order order = PromotionDataGenerator.GetScenarioAOrder();

            data.Add(new object[] { order, 50 });
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    }
}
