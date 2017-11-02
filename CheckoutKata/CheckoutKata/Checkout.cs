using CheckoutKata.Interfaces;
using System.Collections.Generic;

namespace CheckoutKata
{
    public class Checkout : ICheckout
    {
        private readonly ICollection<string> _basket = new List<string>();
        private int _totalPrice;

        public void Scan(string item) => _basket.Add(item);

        public int GetTotalPrice()
        {
            foreach (var item in _basket)
            {
                if (item == "A")
                {
                    _totalPrice += 50;
                }

                if (item == "B")
                {
                    _totalPrice += 30;
                }

                if (item == "C")
                {
                    _totalPrice += 20;
                }

                if (item == "D")
                {
                    _totalPrice += 15;
                }
            }

            return _totalPrice;
        }
    }
}