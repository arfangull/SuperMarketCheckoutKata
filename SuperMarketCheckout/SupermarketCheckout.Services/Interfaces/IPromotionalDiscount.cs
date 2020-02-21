using System.Collections.Generic;
using SupermarketCheckout.Core.Domain;

namespace SupermarketCheckout.Services.Interfaces
{
    public interface IPromotionalDiscount
    {
        IList<Promotion> Promotions { get; }
        void AddPromotion(Promotion promotion);
    }
}
