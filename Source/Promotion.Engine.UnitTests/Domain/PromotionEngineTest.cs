using Moq;
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
        private readonly Mock<IPromotionProvider> _promotionProviderMock;
        public PromotionEngineTest()
        {
            _promotionProviderMock = new Mock<IPromotionProvider>();
            _target = new PromotionEngine(_promotionProviderMock.Object);
        }

        [Theory]
        [MemberData(nameof(PromotionEngineDataGenerator.GetData), MemberType = typeof(PromotionEngineDataGenerator))]
        public void CalculateTotal_ValidOrder_CalculateTotalOrderValue(Order order, double expected)
        {
            _promotionProviderMock.Setup(x => x.GetPromotion(PromotionType.Type1)).Returns(new PromotionType1());
            _promotionProviderMock.Setup(x => x.GetPromotion(PromotionType.Type2)).Returns(new PromotionType2());
            _promotionProviderMock.Setup(x => x.GetPromotion(PromotionType.Type3)).Returns(new PromotionType3());

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
