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
    }
}