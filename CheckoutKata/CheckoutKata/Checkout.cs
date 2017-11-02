using CheckoutKata.Interfaces;

namespace CheckoutKata
{
    public class Checkout : ICheckout
    {
        private int _totalPrice;

        public void Scan(string item)
        {
            if (item == "A")
            {
                _totalPrice = 50;
            }

            if (item == "B")
            {
                _totalPrice = 30;
            }
        }

        public int GetTotalPrice()
        {
            return _totalPrice;
        }
    }
}