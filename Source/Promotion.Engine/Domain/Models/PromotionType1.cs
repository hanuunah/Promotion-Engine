﻿using PromotionEngine.Domain.Interfaces;
using System.Linq;

namespace PromotionEngine.Domain.Models
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

            CalculateItemPriceAfterDescount(order);
        }

        private static void CalculateItemPriceAfterDescount(Order order)
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
