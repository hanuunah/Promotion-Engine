using System.Collections.Generic;

namespace PromotionEngine.Domain.Models
{
    public class Order
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
            throw new System.NotImplementedException();
        }
    }
}
