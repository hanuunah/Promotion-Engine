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
                CalculateItemPrice(order);
                return;
            }

            CalculateItemPriceAfterDiscount(order);
        }

        private static void CalculateItemPriceAfterDiscount(Order order)
        {
            var item = order.Items.First(x => x.Sku.Id.Equals(SkuType.A.Value));
            int discountCount = item.Quantity / ItemCountForDiscount;
            int discountItemCount = discountCount * ItemCountForDiscount;
            var nonDicountItemCount = item.Quantity - discountItemCount;
            item.Price = discountCount * DiscountPrice + nonDicountItemCount * item.Sku.Price;
            order.Total += item.Price;
        }

        private static void CalculateItemPrice(Order order)
        {
            var item = order.Items.First(x => x.Sku.Id.Equals(SkuType.A.Value));
            item.Price = item.Sku.Price * item.Quantity;
            order.Total += item.Price;
        }      


        private static bool IsPromoApplicable(Order order)
        {
            return order.Items.Any() &&
                   order.Items.Any(x => x.Sku.Id.Equals(SkuType.A.Value)) &&
                   (order.Items.First(x => x.Sku.Id.Equals(SkuType.A.Value)).Quantity >= ItemCountForDiscount);
        }
    }
}
