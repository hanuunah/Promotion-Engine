using Promotion.Engine.Domain.Models;

namespace Promotion.Engine.Domain.Interfaces
{
    public interface IPromotionProvider
    {
        IPromotion GetPromotion(PromotionType type);
    }
}