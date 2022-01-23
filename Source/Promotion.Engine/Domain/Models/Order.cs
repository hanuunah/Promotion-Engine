using Promotion.Engine.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Promotion.Engine.Domain.Models
{
    public class Order : IOrder
    {
        public Order(int id, List<PromotionType> promotionTypes)
        {
            Id = id;
            PromotionTypes = promotionTypes;
            Items = new List<OrderItem>();
        }

        public int Id { get; }

        public List<OrderItem> Items { get; set; }

        public double Total { get; set; }

        public List<PromotionType> PromotionTypes { get; }

        public void AddItem(OrderItem item)
        {
            if (!IsValid(item))
            {
                return;
            }

            Items.Add(item);
        }

        private static bool IsValid(OrderItem item)
        {
            return item != null;
        }

        public void CalculateTotal()
        {
            foreach (var item in Items.Where(x => !x.IsPromotionAplied))
            {
                item.Price = item.Sku.Price * item.Quantity;
            }

            foreach (var item in Items)
            {
                Total += item.Price;
            }
        }
    }
}
