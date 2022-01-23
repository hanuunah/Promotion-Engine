using NFluent;
using Promotion.Engine.UnitTests.TestData;
using Promotion.Engine.Domain.Interfaces;
using Promotion.Engine.Domain.Models;
using Xunit;
using System.Linq;

namespace Promotion.Engine.UnitTests.Domain
{
    public class PromotionType3Test
    {
        private readonly IPromotion _target;
        public PromotionType3Test()
        {

            _target = new PromotionType3();
        }

        [Theory]
        [MemberData(nameof(PromotionType3DataGenerator.GetDataForScenarioAandB), MemberType = typeof(PromotionType3DataGenerator))]
        public void Apply_ValidOrder_ApplyPromotionType2Discount(Order order, double expected)
        {
            _target.Apply(order);
            Check.That(order.Items.First(x => x.Sku.Id.Equals(SkuType.C.Value)).Price).Equals(expected);
        }

        [Theory]
        [MemberData(nameof(PromotionType3DataGenerator.GetDataForScenarioC), MemberType = typeof(PromotionType3DataGenerator))]
        public void Apply_ValidOrder_ScenarioC_ApplyPromotionType2Discount(Order order, double expectedC, double expectedD)
        {
            _target.Apply(order);
            Check.That(order.Items.First(x => x.Sku.Id.Equals(SkuType.C.Value)).Price).Equals(expectedC);
            Check.That(order.Items.First(x => x.Sku.Id.Equals(SkuType.D.Value)).Price).Equals(expectedD);
        }

    }
}
