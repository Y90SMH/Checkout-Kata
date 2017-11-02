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
                if (item.Key == "A")
                {
                    var count = item.Count();

                    var quotient = count / 3;
                    var remainder = count % 3;

                    for (var i = 0; i < quotient; i++)
                    {
                        _totalPrice += 130;
                    }
                    _totalPrice += 50 * remainder;
                }

                if (item.Key == "B")
                {
                    _totalPrice += 30;
                }

                if (item.Key == "C")
                {
                    _totalPrice += 20;
                }

                if (item.Key == "D")
                {
                    _totalPrice += 15;
                }
            }

            return _totalPrice;
        }
    }
}