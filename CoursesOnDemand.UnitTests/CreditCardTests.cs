using CoursesOnDemand.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CoursesOnDemand.UnitTests
{
    [TestClass]
    public class CreditCardTests
    {

        [TestMethod]
        public void ValidEntity()
        {
            var ccard = new CreditCard()
            {
                Number = "1234432112344321"
            };
            Assert.AreEqual(string.IsNullOrEmpty(ccard.Number), false);

        }

        [TestMethod]
        public void InvalidEntity()
        {
            var ccard = new CreditCard();
            Assert.AreEqual(string.IsNullOrEmpty(ccard.Number), true);

        }
    }    
}
