using System.Collections.Generic;
using System.Linq;
using SupermarketCheckout.Core.Domain;
using SupermarketCheckout.Services.Interfaces;

namespace SupermarketCheckout.Services
{
    public class Checkout : ICheckout
    {
        private IList<Product> _scannProducts;
        public IList<Product> ScannedProducts => _scannProducts;
        private readonly IPromotionalDiscount _promotionalDiscount;

        public Checkout(IPromotionalDiscount promotionalDiscount) // Dependency Injection
        {
            _promotionalDiscount = promotionalDiscount;
            _scannProducts = new List<Product>();
        }

        public void Scan(Product product)
        {
            _scannProducts.Add(product);
        }

        public decimal CalculateTotalPrice()
        {
            decimal checkoutTotal = 0;

            // Group them By Sku and determine the promotional price if any.
            var products = _scannProducts.GroupBy(g => g.Sku);

            foreach (var product in products)
            {
                var promotionForProduct = product.Select(x => x.Promotion).FirstOrDefault();
                if (promotionForProduct != null)
                {
                    var productsForSkuCount = product.Count();
                    var extra = productsForSkuCount - promotionForProduct.Quantity;

                    if (extra < 0) // Nothing to Offer as per product Quantity
                        checkoutTotal += product.Sum(g => g.UnitPrice);
                    else
                    {
                        checkoutTotal += promotionForProduct.OfferPrice; // Customer is purchasing quantity for which promotion is there.
                        checkoutTotal += extra * product.First().UnitPrice;
                    }
                }
                else
                    checkoutTotal += product.Sum(x => x.UnitPrice);
            }

            return checkoutTotal;
        }
    }
}
