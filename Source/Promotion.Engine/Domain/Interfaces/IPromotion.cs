
using PromotionEngine.Domain.Models;

namespace PromotionEngine.Domain.Interfaces
{
    public interface IPromotion
    {
        void Apply(Order order);
    }
}