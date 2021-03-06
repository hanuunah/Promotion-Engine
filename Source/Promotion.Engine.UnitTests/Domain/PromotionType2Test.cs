using NFluent;
using Promotion.Engine.UnitTests.TestData;
using Promotion.Engine.Domain.Interfaces;
using Promotion.Engine.Domain.Models;
using Xunit;
using System.Linq;

namespace Promotion.Engine.UnitTests.Domain
{
    public class PromotionType2Test
    {
        private readonly IPromotion _target;
        public PromotionType2Test()
        {

            _target = new PromotionType2();
        }

        [Theory]
        [MemberData(nameof(PromotionType2DataGenerator.GetData), MemberType = typeof(PromotionType2DataGenerator))]
        public void Apply_ValidOrder_ApplyPromotionType2Discount(Order order, double expected)
        {
            _target.Apply(order);
            Check.That(order.Items.First(x => x.Sku.Id.Equals(SkuType.B.Value)).Price).Equals(expected);
        }

    }
}
