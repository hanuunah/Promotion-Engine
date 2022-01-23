
using Promotion.Engine.Domain.Models;

namespace Promotion.Engine.Domain.Interfaces
{
    public interface IPromotion
    {
        void Apply(Order order);
    }
}