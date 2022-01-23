using Promotion.Engine.Domain.Models;

namespace Promotion.Engine.Domain.Interfaces
{
    public interface IPromotionEngine
    {
        void CalculateTotal(Order order);
    }
}