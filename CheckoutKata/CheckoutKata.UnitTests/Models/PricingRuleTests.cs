using System;
using CheckoutKata.Models;
using NUnit.Framework;

namespace CheckoutKata.UnitTests.Models
{
    [TestFixture]
    public class PricingRuleTests
    {
        private readonly string _validSku = "A";
        private readonly int _validDenominator = 1;
        private readonly int _validSpecialPrice = 0;

        [Test]
        public void Cannot_Create_PricingRule_With_NullOrWhitespace_Sku()
        {
            Assert.Throws<ArgumentException>(
                () => new PricingRule(null, _validSpecialPrice, _validDenominator)
            );
        }

        [Test]
        public void Cannot_Create_PricingRule_With_Zero_For_Denominator()
        {
            Assert.Throws<ArgumentOutOfRangeException>(
                () => new PricingRule(_validSku, _validSpecialPrice, 0)
            );
        }
    }
}