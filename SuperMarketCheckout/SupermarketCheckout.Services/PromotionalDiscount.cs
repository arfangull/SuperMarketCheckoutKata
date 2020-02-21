using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SupermarketCheckout.Core.Domain;
using SupermarketCheckout.Services.Interfaces;

namespace SupermarketCheckout.Services
{
    /// <summary>
    /// This Service can be used to add Promotions and calculate discounts independently
    /// </summary>
    public class PromotionalDiscount : IPromotionalDiscount
    {
        private IList<Promotion> _promotions;
        public IList<Promotion> Promotions => _promotions;

        public PromotionalDiscount()
        {
            _promotions = new List<Promotion>();
        }
        public void AddPromotion(Promotion promotion)
        {
            _promotions.Add(promotion);            
        }
        }
}
