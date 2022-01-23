using NFluent;
using Promotion.Engine.Domain.Interfaces;
using Promotion.Engine.Domain.Models;
using System.Collections.Generic;
using Xunit;

namespace Promotion.Engine.UnitTests.Domain
{
    public class PromotionEngineTest
    {
        private readonly IPromotionEngine _target;
        public PromotionEngineTest()
        {
            var promoTypes = new List<PromotionType>
            {
                PromotionType.Type1,
                PromotionType.Type2,
                PromotionType.Type3,
            };

            _target = new PromotionEngine();
        }

        [Fact]
        public void CalculateTotal_ValidOrder_CalculateTotalOrderValue()
        {
            
        }

        [Fact]
        public void CalculateTotal_InvalidOrder_SkipCalculation()
        {

        }

    }
}
