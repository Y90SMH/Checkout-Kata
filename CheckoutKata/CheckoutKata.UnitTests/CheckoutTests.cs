using CheckoutKata.Interfaces;
using NUnit.Framework;

namespace CheckoutKata.UnitTests
{
    [TestFixture]
    public class CheckoutTests
    {
        private ICheckout _sut;

        [SetUp]
        public void Setup()
        {
            _sut = new Checkout();
        }

        [Test]
        public void TotalPrice_Zero_If_No_Items_Scanned()
        {
            var result = _sut.GetTotalPrice();

            Assert.That(result, Is.EqualTo(0));
        }
    }
}