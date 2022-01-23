
using Promotion.Engine.Domain.Interfaces;

namespace Promotion.Engine.Domain.Models
{
    public class PromotionEngine : IPromotionEngine
    {
        public void CalculateTotal(Order order)
        {
            if (!IsValid(order))
            {
                return;
            }

            var promotionProvider = new PromotionProvider();
            foreach (var type in order.PromotionTypes)
            {
                var promotion = promotionProvider.GetPromotion(type);
                promotion.Apply(order);
            }
        }

        private static bool IsValid(Order order)
        {
            return order != null;
        }
    }
}
