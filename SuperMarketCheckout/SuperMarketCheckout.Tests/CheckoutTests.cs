using System;
using System.Collections.Generic;
using Xunit;

namespace SuperMarketCheckout.Tests
{
    public class CheckoutTests
    {
        [Fact]
        public void Scan_No_Item_CalculateTotalPrice_Should_Return_Zero()
        {
            // Arrange
            var product = new Product();
            var checkout = new Checkout();

            // Act
            var total = checkout.CalculateTotalPrice();

            // Assert

            Assert.Equal(expected: 0, total);

        }
        [Fact]
        public void Scan_SingleProduct_CalculateTotalPrice_Should_Return_Product_TotalPrice()
        {
            // Arrange
            var product = new Product();
            var checkout = new Checkout();

            // Act
            checkout.Scan(product);
            var total = checkout.CalculateTotalPrice();

            // Assert

            Assert.Equal(expected: 0.50, total);
        }
        [Fact]
        public void Scan_MultipleProducts_CalculateTotalPrice_Should_Return_Products_TotalPrice()
        {
            // Arrange
            var product1 = new Product(); // A99
            var product2 = new Product(); // B15
            var checkout = new Checkout();

            // Act
            checkout.Scan(product1);
            checkout.Scan(product2);
            var total = checkout.CalculateTotalPrice();

            // Assert

            Assert.Equal(expected: 0.80, total);
        }
        [Fact]
        public void Scan_MultipleProducts_With_SpecialOffers_CalculateTotalPrice_Should_Return_Discounted_TotalPrice()
        {
            // Arrange
            var product = new Product(); // B15
            var checkout = new Checkout();
            var promotionalDiscount = new PromotionalDicsount();
            // Act
            checkout.Scan(product);
            checkout.Scan(product);
            var total = checkout.CalculateTotalPrice();

            // Assert

            Assert.Equal(expected: 0.45, total);
        }
    }

    public class PromotionalDicsount
    {
    }

    public class Checkout
    {
        private IList<Product> _products;

        public Checkout()
        {
            _products = new List<Product>();
        }

        public double CalculateTotalPrice()
        {
            // This could anything as its a Red state and will be implemented/refactored. 

            throw new NotImplementedException();
        }

        public void Scan(Product product)
        {
            _products.Add(product);
        }
    }

    public class Product
    {
    }
}
