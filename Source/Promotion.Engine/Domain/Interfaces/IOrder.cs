using Promotion.Engine.Domain.Models;
using System.Collections.Generic;

namespace Promotion.Engine.Domain.Interfaces
{
    public interface IOrder
    {
        int Id { get; }
        List<OrderItem> Items { get; set; }
        List<PromotionType> PromotionTypes { get; }
        double Total { get; set; }

        void AddItem(OrderItem item);
        void CalculateTotal();
    }
}