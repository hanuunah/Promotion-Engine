using PromotionEngine.Domain.Interfaces;

namespace PromotionEngine.Domain.Models
{
    public class PromotionProvider : IPromotionProvider
    {
        public IPromotion GetPromotion(PromotionType type)
        {
            if (!IsValid(type))
            {
                return null;
            }

            if (type.Value == PromotionType.Type1.Value)
            {
                return new PromotionType1();
            }

            if (type.Value == PromotionType.Type2.Value)
            {
                return new PromotionType2();
            }

            if (type.Value == PromotionType.Type3.Value)
            {
                return new PromotionType3();
            }

            return null;
        }

        private static bool IsValid(PromotionType type)
        {
            return type != null;
        }
    }
}
