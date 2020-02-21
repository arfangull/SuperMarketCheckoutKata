using System.Collections.Generic;
using SupermarketCheckout.Core.Domain;

namespace SupermarketCheckout.Services.Interfaces
{
    public interface ICheckout
    {
        IList<Product> ScannedProducts { get; }
        void Scan(Product product);
        decimal CalculateTotalPrice();
    }
}
