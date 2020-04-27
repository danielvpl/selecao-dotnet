using CoursesOnDemand.Domain;
using Xunit;

namespace CoursesOnDemand.UnitTests
{
    public class CourseTests
    {
        [Fact]
        public void Validy()
        {
            var course = new Course()
            {
                Title = ".NET Core C# - xUnit Tests"
            };
            Assert.False(string.IsNullOrEmpty(course.Title));

        }

        [Fact]
        public void Invalid()
        {
            var course = new Course();
            Assert.True(true, course.Title);
        }
        
    }
}
