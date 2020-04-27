using CoursesOnDemand.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CoursesOnDemand.UnitTests
{
    class CourseTests
    {
        [TestMethod]
        public void ValidEntity()
        {
            var course = new Course()
            {
                Title = ".NET Core C# - xUnit Tests"
            };
            Assert.AreEqual(string.IsNullOrEmpty(course.Title), false);

        }

        [TestMethod]
        public void InvalidEntity()
        {
            var course = new Course();
            Assert.AreEqual(string.IsNullOrEmpty(course.Title), true);
        }
    }
}
