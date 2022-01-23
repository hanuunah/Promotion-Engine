using PromotionEngine.Domain.Models;

namespace PromotionEngine.Domain.Interfaces
{
    public interface IPromotionEngine
    {
        void CalculateTotal(Order order);
    }
}