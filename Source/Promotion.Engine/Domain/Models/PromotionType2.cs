using Promotion.Engine.Domain.Interfaces;
using System.Linq;


namespace Promotion.Engine.Domain.Models
{
    public class PromotionType2 : IPromotion
    {
        private const int ItemCountForDiscount = 2;
        private const int DiscountPrice = 45;

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
            var item = order.Items.First(x => x.Sku.Id.Equals(SkuType.B.Value));
            int discountCount = item.Quantity / ItemCountForDiscount;
            int discountItemCount = discountCount * ItemCountForDiscount;
            var nonDicountItemCount = item.Quantity - discountItemCount;
            item.Price += discountCount * DiscountPrice;
            item.Price += nonDicountItemCount * item.Sku.Price;
            item.IsPromotionAplied = true;
        }

        private static bool IsPromoApplicable(Order order)
        {
            return order.Items.Any() &&
                   order.Items.Any(x => x.Sku.Id.Equals(SkuType.B.Value)) &&
                   (order.Items.First(x => x.Sku.Id.Equals(SkuType.B.Value)).Quantity >= ItemCountForDiscount);
        }
    }
}
