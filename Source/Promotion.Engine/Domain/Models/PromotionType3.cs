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
                CalculateItemPrice(order);
                return;
            }

            CalculateItemPriceAfterDiscount(order);
        }

        private void CalculateItemPrice(Order order)
        {
            CalculateItemCPrice(order);
            CalculateItemDPrice(order);
        }

        private static void CalculateItemCPrice(Order order)
        {
            if (!order.Items.Any(x => x.Sku.Id.Equals(SkuType.C.Value)))
            {
                return;
            }

            var item = order.Items.First(x => x.Sku.Id.Equals(SkuType.C.Value));
            item.Price = item.Sku.Price * item.Quantity;
            order.Total += item.Price;
        }

        private static void CalculateItemDPrice(Order order)
        {
            if (!order.Items.Any(x => x.Sku.Id.Equals(SkuType.D.Value)))
            {
                return;
            }

            var item = order.Items.First(x => x.Sku.Id.Equals(SkuType.D.Value));
            item.Price = item.Sku.Price * item.Quantity;
            order.Total += item.Price;
        }

        private static void CalculateItemPriceAfterDiscount(Order order)
        {
            var itemC = order.Items.First(x => x.Sku.Id.Equals(SkuType.C.Value));
            var itemD = order.Items.First(x => x.Sku.Id.Equals(SkuType.D.Value));
            var discountItemCount = Math.Min(itemC.Quantity, itemD.Quantity);

            CalculateItemCPriceAfterDiscount(order, itemC, discountItemCount);
            CalculateItemDPriceAfterDiscount(order, itemD, discountItemCount);

        }

        private static void CalculateItemCPriceAfterDiscount(Order order, OrderItem item, int discountItemCount)
        {
            var nonDicountItemCount = item.Quantity - discountItemCount;
            item.Price = nonDicountItemCount * item.Sku.Price;
            order.Total += item.Price;
        }

        private static void CalculateItemDPriceAfterDiscount(Order order, OrderItem item, int discountItemCount)
        {
            var nonDicountItemCount = item.Quantity - discountItemCount;
            item.Price += discountItemCount * DiscountPrice;
            item.Price += nonDicountItemCount * item.Sku.Price;
            order.Total += item.Price;
        }

        private static bool IsPromoApplicable(Order order)
        {
            return order.Items.Any() &&
                   order.Items.Any(x => x.Sku.Id.Equals(SkuType.C.Value) &&
                   order.Items.Any(x => x.Sku.Id.Equals(SkuType.D.Value)));
        }
    }
}
