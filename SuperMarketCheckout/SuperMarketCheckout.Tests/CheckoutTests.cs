using SupermarketCheckout.Services.Interfaces;
using System;
using System.Collections.Generic;
using SupermarketCheckout.Core.Domain;
using SupermarketCheckout.Services;
using Xunit;

namespace SuperMarketCheckout.Tests
{
    public class CheckoutTests
    {
        private readonly ICheckout _checkout;

        public CheckoutTests()
        {
            _checkout = new Checkout();
        }

        [Fact]
        public void Scan_No_Item_CalculateTotalPrice_Should_Return_Zero()
        {
            // Arrange
            var product = new Product { Sku = "", UnitPrice = 0 };

            // Act
            // We are not going to scan anything
            var total = _checkout.CalculateTotalPrice();

            // Assert
            Assert.Equal(expected: 0, total);

        }
        [Fact]
        public void Scan_SingleProduct_CalculateTotalPrice_Should_Return_Product_TotalPrice()
        {
            // Arrange
            var product = new Product { Sku = "A99", UnitPrice = 0.50m };
            // Act
            _checkout.Scan(product);
            var total = _checkout.CalculateTotalPrice();

            // Assert
            Assert.Equal(expected: 0.50m, total);
        }
        [Fact]
        public void Scan_MultipleProducts_CalculateTotalPrice_Should_Return_Products_TotalPrice()
        {
            // Arrange
            var A99 = new Product { Sku = "A99", UnitPrice = 0.50m };
            var B15 = new Product { Sku = "B15", UnitPrice = 0.30m };

            // Act
            _checkout.Scan(A99);
            _checkout.Scan(B15);
            var total = _checkout.CalculateTotalPrice();

            // Assert
            Assert.Equal(expected: 0.80m, total);
        }
        [Fact]
        public void Scan_AllProducts_CalculateTotalPrice_Should_Return_Products_TotalPrice()
        {
            // Arrange
            var A99 = new Product { Sku = "A99", UnitPrice = 0.50m };
            var B15 = new Product { Sku = "B15", UnitPrice = 0.30m };
            var C40 = new Product { Sku = "C40", UnitPrice = 0.60m };

            // Act
            _checkout.Scan(A99);
            _checkout.Scan(B15);
            _checkout.Scan(C40);

            var total = _checkout.CalculateTotalPrice();

            // Assert
            Assert.Equal(expected: 1.40m, total);
        }
        [Fact]
        public void Scan_MultipleProducts_With_SpecialOffers_CalculateTotalPrice_Should_Return_TotalPrice()
        {
            // Arrange
            var A99 = new Product { Sku = "A99", UnitPrice = 0.50m };
            var B15 = new Product { Sku = "B15", UnitPrice = 0.30m };

            // Act
            _checkout.Scan(A99);
            _checkout.Scan(B15);
            _checkout.Scan(B15);

            var total = _checkout.CalculateTotalPrice();

            // Assert
            Assert.Equal(expected: 1.10m, total);
        }
    }

}
