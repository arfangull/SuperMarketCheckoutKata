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

        public Checkout()
        {
            _scannProducts = new List<Product>();
        }



        public void Scan(Product product)
        {
            _scannProducts.Add(product);
        }

        public decimal CalculateTotalPrice()
        {
            var total = _scannProducts.Sum(x => x.UnitPrice);
            return total;
        }
    }

}
