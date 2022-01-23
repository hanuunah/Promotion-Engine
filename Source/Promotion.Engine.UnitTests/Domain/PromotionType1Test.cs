using NFluent;
using Promotion.Engine.UnitTests.TestData;
using PromotionEngine.Domain.Interfaces;
using PromotionEngine.Domain.Models;
using Xunit;

namespace Promotion.Engine.UnitTests.Domain
{
    public class PromotionType1Test
    {
        private readonly IPromotion _target;
        public PromotionType1Test()
        {

            _target = new PromotionType1();
        }

        [Theory]
        [ClassData(typeof(PromotionType1DataGenerator))]
        public void Apply_ValidOrder_ApplyPromotionType1Discount(Order order, double expected)
        {
            _target.Apply(order);
            Check.That(order.Total).Equals(expected);
        }       

    }
}
