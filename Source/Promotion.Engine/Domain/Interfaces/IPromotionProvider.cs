using PromotionEngine.Domain.Models;

namespace PromotionEngine.Domain.Interfaces
{
    public interface IPromotionProvider
    {
        IPromotion GetPromotion(PromotionType type);
    }
}