using System;

namespace CheckoutKata.Models
{
    public class PricingRule
    {
        public PricingRule(string sku, int specialPrice, int denominator)
        {
            Denominator = denominator != 0 ? denominator : throw new ArgumentOutOfRangeException($"{nameof(denominator)} cannot be 0.");
            Sku = string.IsNullOrWhiteSpace(sku) ? sku : throw new ArgumentException("Sku cannot be null or empty.");
            SpecialPrice = specialPrice;
        }

        public string Sku { get; }

        public int SpecialPrice { get; }

        public int Denominator { get; }
    }
}