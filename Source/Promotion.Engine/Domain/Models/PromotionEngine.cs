
using Promotion.Engine.Domain.Interfaces;

namespace Promotion.Engine.Domain.Models
{
    public class PromotionEngine : IPromotionEngine
    {
        private readonly IPromotionProvider _promotionProvider;

        public PromotionEngine(IPromotionProvider promotionProvider)
        {
            _promotionProvider = promotionProvider;
        }

        public void CalculateTotal(Order order)
        {
            if (!IsValid(order))
            {
                return;
            }

            foreach (var type in order.PromotionTypes)
            {
                var promotion = _promotionProvider.GetPromotion(type);
                //polymorphism magic
                promotion.Apply(order);
            }

            order.CalculateTotal();
        }

        private static bool IsValid(Order order)
        {
            return order != null;
        }
    }
}
