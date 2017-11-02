namespace CheckoutKata.Interfaces
{
    interface ICheckout
    {
        void Scan(string item);
        int GetTotalPrice();
    }
}