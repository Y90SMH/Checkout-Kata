﻿using CheckoutKata.Interfaces;
using CheckoutKata.Models;
using NUnit.Framework;
using System.Collections.Generic;

namespace CheckoutKata.UnitTests
{
    [TestFixture]
    public class CheckoutTests
    {
        private ICheckout _sut;

        [SetUp]
        public void Setup()
        {
            _sut = new Checkout(null);
        }

        [Test]
        public void TotalPrice_Zero_If_No_Items_Scanned()
        {
            var result = _sut.GetTotalPrice();

            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void TotalPrice_Correct_If_One_A_Scanned()
        {
            const string item = "A";

            _sut.Scan(item);

            var result = _sut.GetTotalPrice();

            Assert.That(result, Is.EqualTo(50));
        }

        [Test]
        public void TotalPrice_Correct_If_One_B_Scanned()
        {
            const string item = "B";

            _sut.Scan(item);

            var result = _sut.GetTotalPrice();

            Assert.That(result, Is.EqualTo(30));
        }

        [Test]
        public void TotalPrice_Correct_If_One_A_And_One_B_Scanned()
        {
            const string itemA = "A";
            const string itemB = "B";

            _sut.Scan(itemA);
            _sut.Scan(itemB);

            var result = _sut.GetTotalPrice();

            Assert.That(result, Is.EqualTo(80));
        }

        [Test]
        public void TotalPrice_Correct_If_One_Of_Each_Item_Scanned()
        {
            var items = new[]
            {
                "A",
                "B",
                "C",
                "D"
            };

            foreach (var item in items)
            {
                _sut.Scan(item);
            }

            var result = _sut.GetTotalPrice();

            Assert.That(result, Is.EqualTo(115));
        }

        [Test]
        public void TotalPrice_Correct_If_Variable_Amount_Of_Each_Item_Scanned()
        {
            var items = new[]
            {
                "A",
                "A",
                "B",
                "C",
                "C",
                "D"
            };

            foreach (var item in items)
            {
                _sut.Scan(item);
            }

            var result = _sut.GetTotalPrice();

            Assert.That(result, Is.EqualTo(185));
        }

        [Test]
        public void TotalPrice_Correct_If_Three_A_Scanned()
        {
            var pricingRules = new List<PricingRule>
            {
                new PricingRule("A", 130, 3)
            };

            var sut = new Checkout(pricingRules);

            var items = new[]
            {
                "A",
                "A",
                "A"
            };

            foreach (var item in items)
            {
                sut.Scan(item);
            }

            var result = sut.GetTotalPrice();

            Assert.That(result, Is.EqualTo(130));
        }

        [Test]
        public void TotalPrice_Correct_If_Two_B_Scanned()
        {
            var pricingRules = new List<PricingRule>
            {
                new PricingRule("B", 45, 2)
            };

            var sut = new Checkout(pricingRules);

            var items = new[]
            {
                "B",
                "B"
            };

            foreach (var item in items)
            {
                sut.Scan(item);
            }

            var result = sut.GetTotalPrice();

            Assert.That(result, Is.EqualTo(45));
        }

        [Test]
        public void TotalPrice_Correct_With_Alternative_B_Pricing_Rule()
        {
            var pricingRules = new List<PricingRule>
            {
                new PricingRule("B", 50, 2)
            };

            var sut = new Checkout(pricingRules);

            var items = new[]
            {
                "B",
                "B"
            };

            foreach (var item in items)
            {
                sut.Scan(item);
            }

            var result = sut.GetTotalPrice();

            Assert.That(result, Is.EqualTo(50));
        }

        [Test]
        public void TotalPrice_Correct_With_Multiple_Pricing_Rules()
        {
            var pricingRules = new List<PricingRule>
            {
                new PricingRule("A", 130, 3),
                new PricingRule("B", 45, 2)
            };

            var sut = new Checkout(pricingRules);

            var items = new[]
            {
                "A",
                "B",
                "C",
                "D",
                "A",
                "B",
                "A"
            };

            foreach (var item in items)
            {
                sut.Scan(item);
            }

            var result = sut.GetTotalPrice();

            Assert.That(result, Is.EqualTo(210));
        }
    }
}