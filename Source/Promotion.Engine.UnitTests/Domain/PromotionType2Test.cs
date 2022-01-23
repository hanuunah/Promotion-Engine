using NFluent;
using Promotion.Engine.UnitTests.TestData;
using PromotionEngine.Domain.Interfaces;
using PromotionEngine.Domain.Models;
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
        [ClassData(typeof(PromotionType2DataGenerator))]
        public void Apply_ValidOrder_ApplyPromotionType1Discount(Order order, double expected)
        {
            _target.Apply(order);
            Check.That(order.Items.First(x => x.Sku.Id.Equals(SkuType.A.Value)).Price).Equals(expected);
        }

    }
}
