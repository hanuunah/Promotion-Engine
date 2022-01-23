using NFluent;
using Promotion.Engine.UnitTests.TestData;
using PromotionEngine.Domain.Interfaces;
using PromotionEngine.Domain.Models;
using Xunit;

namespace Promotion.Engine.UnitTests.Domain
{
    public class PromotionProviderTest
    {
        private readonly IPromotionProvider _target;
        public PromotionProviderTest()
        {

            _target = new PromotionProvider();
        }

        [Theory]
        [ClassData(typeof(TestDataGenerator))]
        public void GetPromotion_ValidPromotionType_ReturnPromotionType(PromotionType promotionType)
        {
            var promotion = _target.GetPromotion(promotionType);
            Check.That(promotion).IsNotNull();
        }

        [Fact]
        public void GetPromotion_InvalidValidPromotionType_ReturnNull()
        {
            var promotion = _target.GetPromotion(new PromotionType(999, "Invalid"));
            Check.That(promotion).IsNull();
        }

        [Fact]
        public void GetPromotion_NullArgument_ReturnNull()
        {
            var promotion = _target.GetPromotion(null);
            Check.That(promotion).IsNull();
        }
    }
}
