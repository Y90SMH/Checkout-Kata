using CheckoutKata.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace CheckoutKata
{
    public class Checkout : ICheckout
    {
        private readonly ICollection<string> _basket = new List<string>();
        private int _totalPrice;

        public void Scan(string item) => _basket.Add(item);

        public int GetTotalPrice()
        {
            var items = _basket.GroupBy(x => x);

            foreach (var item in items)
            {
                var count = item.Count();

                if (item.Key == "A")
                {
                    _totalPrice += CalculateTotalForSku(count, 50, 130, 3);
                }

                if (item.Key == "B")
                {
                    _totalPrice += CalculateTotalForSku(count, 30, 45, 2);
                }

                if (item.Key == "C")
                {
                    _totalPrice += CalculateTotalForSku(count, 20);
                }

                if (item.Key == "D")
                {
                    _totalPrice += CalculateTotalForSku(count, 15);
                }
            }

            return _totalPrice;
        }

        private static int CalculateTotalForSku(int count, int unitPrice)
        {
            return count * unitPrice;
        }

        private static int CalculateTotalForSku(int count, int unitPrice, int specialPrice, int denominator)
        {
            var skuTotalPrice = 0;

            var quotient = count / denominator;
            var remainder = count % denominator;

            for (var i = 0; i < quotient; i++)
            {
                skuTotalPrice += specialPrice;
            }

            skuTotalPrice += unitPrice * remainder;

            return skuTotalPrice;
        }
    }
}