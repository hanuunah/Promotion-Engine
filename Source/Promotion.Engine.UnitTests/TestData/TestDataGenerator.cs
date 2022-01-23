using PromotionEngine.Domain.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Promotion.Engine.UnitTests.TestData
{
    public class TestDataGenerator : IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new List<object[]>
    {
        new object[] { PromotionType.Type1},
        new object[] { PromotionType.Type2}
    };

        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public static IEnumerable<object[]> GetPromotionTypeFromDataGenerator()
        {
            yield return new object[]
            {
           PromotionType.Type2,
            };

        }

    }
}
