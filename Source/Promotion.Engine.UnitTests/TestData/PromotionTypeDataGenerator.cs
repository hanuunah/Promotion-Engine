using Promotion.Engine.Domain.Models;
using System.Collections;
using System.Collections.Generic;

namespace Promotion.Engine.UnitTests.TestData
{
    public class PromotionTypeDataGenerator : IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new List<object[]>
        {
        new object[] { PromotionType.Type1},
        new object[] { PromotionType.Type2},
        new object[] { PromotionType.Type3}
        };

        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    }
}
