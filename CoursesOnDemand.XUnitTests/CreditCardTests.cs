using CoursesOnDemand.Domain;
using Xunit;

namespace CoursesOnDemand.UnitTests
{
    public class CreditCardTests
    {

        [Fact]
        public void ValidEntity()
        {
            var ccard = new CreditCard()
            {
                Number = "1234432112344321"
            };
            Assert.False(string.IsNullOrEmpty(ccard.Number));
        }

        [Fact]
        public void InvalidEntity()
        {
            var ccard = new CreditCard();
            Assert.True(string.IsNullOrEmpty(ccard.Number));
        }        
    }    
}
