using CheckoutKata.Interfaces;
using CheckoutKata.Models;
using System.Collections.Generic;
using System.Linq;

namespace CheckoutKata
{
    public class Checkout : ICheckout
    {
        private readonly ICollection<string> _basket = new List<string>();
        private readonly IEnumerable<PricingRule> _pricingRules;
        private int _totalPrice;

        public Checkout(IEnumerable<PricingRule> pricingRules)
        {
            _pricingRules = pricingRules ?? Enumerable.Empty<PricingRule>();
        }

        public void Scan(string item) => _basket.Add(item);

        public int GetTotalPrice()
        {
            var items = _basket.GroupBy(x => x);

            foreach (var item in items)
            {
                var unitPrice = 0;
                switch (item.Key)
                {
                    case "A":
                        unitPrice = 50;
                        break;
                    case "B":
                        unitPrice = 30;
                        break;
                    case "C":
                        unitPrice = 20;
                        break;
                    case "D":
                        unitPrice = 15;
                        break;
                }

                _totalPrice += CalculateTotalForSku(item.Key, item.Count(), unitPrice);
            }

            return _totalPrice;
        }

        private int CalculateTotalForSku(string sku, int count, int unitPrice)
        {
            var pricingRule = _pricingRules.SingleOrDefault(x => x.Sku == sku);

            if (pricingRule == null)
            {
                return count * unitPrice;
            }

            var skuTotalPrice = 0;

            var quotient = count / pricingRule.Denominator;
            var remainder = count % pricingRule.Denominator;

            for (var i = 0; i < quotient; i++)
            {
                skuTotalPrice += pricingRule.SpecialPrice;
            }

            skuTotalPrice += unitPrice * remainder;

            return skuTotalPrice;
        }
    }
}