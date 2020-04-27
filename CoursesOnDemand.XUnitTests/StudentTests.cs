using CoursesOnDemand.Domain;
using Xunit;

namespace CoursesOnDemand.UnitTests
{
    public class StudentTests
    {
        [Fact]
        public void ValidEntity()
        {
            var student = new Student()
            {
                FirstName = "Daniel"                
            };
            Assert.False(string.IsNullOrEmpty(student.FirstName));

        }

        [Fact]
        public void InvalidEntity()
        {
            var student = new Student();
            Assert.True(string.IsNullOrEmpty(student.FirstName));
        }

        [Theory]
        [InlineData("Daniel")]
        public void ChangeStudentName(string firstname)
        {
            Assert.False(string.IsNullOrEmpty(firstname));
        }
    }
}
