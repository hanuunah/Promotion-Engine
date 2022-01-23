using Promotion.Engine.Domain.Interfaces;
using System.Linq;

namespace Promotion.Engine.Domain.Models
{
    public class PromotionType1 : IPromotion
    {
        private const int ItemCountForDiscount = 3;
        private const int DiscountPrice = 130;

        public void Apply(Order order)
        {
            if (!IsPromoApplicable(order))
            {
                return;
            }

            CalculateItemPrice(order);
        }

        private static void CalculateItemPrice(Order order)
        {
            var item = order.Items.First(x => x.Sku.Id.Equals(SkuType.A.Value));
            int discountCount = item.Quantity / ItemCountForDiscount;
            int discountItemCount = discountCount * ItemCountForDiscount;
            var nonDicountItemCount = item.Quantity - discountItemCount;
            item.Price = discountCount * DiscountPrice + nonDicountItemCount * item.Sku.Price;
            item.IsPromotionAplied = true;
        }      


        private static bool IsPromoApplicable(Order order)
        {
            return order.Items.Any() &&
                   order.Items.Any(x => x.Sku.Id.Equals(SkuType.A.Value)) &&
                   (order.Items.First(x => x.Sku.Id.Equals(SkuType.A.Value)).Quantity >= ItemCountForDiscount);
        }
    }
}
