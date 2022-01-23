using NFluent;
using Promotion.Engine.Domain.Interfaces;
using Promotion.Engine.Domain.Models;
using Promotion.Engine.UnitTests.TestData;
using Xunit;

namespace Promotion.Engine.UnitTests.Domain
{
    public class PromotionEngineTest
    {
        private readonly IPromotionEngine _target;
        public PromotionEngineTest()
        {
          

            _target = new PromotionEngine();
        }

        [Theory]
        [MemberData(nameof(PromotionEngineDataGenerator.GetData), MemberType = typeof(PromotionEngineDataGenerator))]
        public void CalculateTotal_ValidOrder_CalculateTotalOrderValue(Order order, double expected)
        {
            _target.CalculateTotal(order);
            Check.That(order.Total).Equals(expected);
        }

        [Fact]
        public void CalculateTotal_InvalidOrder_SkipCalculation()
        {
            _target.CalculateTotal(null);
        }

    }
}
