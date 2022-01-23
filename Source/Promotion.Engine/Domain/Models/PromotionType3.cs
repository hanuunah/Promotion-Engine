using Promotion.Engine.Domain.Interfaces;
using System;
using System.Linq;

namespace Promotion.Engine.Domain.Models
{
    public class PromotionType3 : IPromotion
    {
        private const int DiscountPrice = 30;

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
            var itemC = order.Items.First(x => x.Sku.Id.Equals(SkuType.C.Value));
            var itemD = order.Items.First(x => x.Sku.Id.Equals(SkuType.D.Value));
            var discountItemCount = Math.Min(itemC.Quantity, itemD.Quantity);

            CalculateItemPriceC(order, itemC, discountItemCount);
            CalculateItemPriceD(order, itemD, discountItemCount);

        }

        private static void CalculateItemPriceC(Order order, OrderItem item, int discountItemCount)
        {
            var nonDicountItemCount = item.Quantity - discountItemCount;
            item.Price = nonDicountItemCount * item.Sku.Price;
            item.IsPromotionAplied = true;
        }

        private static void CalculateItemPriceD(Order order, OrderItem item, int discountItemCount)
        {
            var nonDicountItemCount = item.Quantity - discountItemCount;
            item.Price += discountItemCount * DiscountPrice;
            item.Price += nonDicountItemCount * item.Sku.Price;
            item.IsPromotionAplied = true;
        }

        private static bool IsPromoApplicable(Order order)
        {
            return order.Items.Any() &&
                   order.Items.Any(x => x.Sku.Id.Equals(SkuType.C.Value) &&
                   order.Items.Any(x => x.Sku.Id.Equals(SkuType.D.Value)));
        }
    }
}
