using CoursesOnDemand.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit.Sdk;

namespace CoursesOnDemand.UnitTests
{
    [TestClass]
    public class StudentTests
    {
        [TestMethod]
        public void ValidEntity()
        {
            var student = new Student()
            {
                FirstName = "Daniel"                
            };
            Assert.AreEqual(string.IsNullOrEmpty(student.FirstName), false);

        }

        [TestMethod]
        public void InvalidEntity()
        {
            var student = new Student();
            Assert.AreEqual(string.IsNullOrEmpty(student.FirstName), true);
        }
    }
}
