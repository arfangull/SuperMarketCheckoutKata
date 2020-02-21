using System;
using System.Collections.Generic;
using System.Text;

namespace SupermarketCheckout.Core.Domain
{
    public class Promotion
    {
        public string Sku { get; set; }
        public int Quantity { get; set; }
        public decimal OfferPrice { get; set; }
    }
}
