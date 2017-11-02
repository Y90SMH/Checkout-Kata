using CheckoutKata.Interfaces;

namespace CheckoutKata
{
    public class Checkout : ICheckout
    {
        public void Scan(string item)
        {
            throw new System.NotImplementedException();
        }

        public int GetTotalPrice()
        {
            return 0;
        }
    }
}