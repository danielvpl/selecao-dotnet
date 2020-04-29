using CoursesOnDemand.Domain;
using System.Collections.Generic;

namespace CoursesOnDemand.Repository
{
    /// <summary>
    /// This static class temporarily saves the values ​​for running the application
    /// </summary>
    public static class FakeRepository
    {
        public static List<Student> Students { get; set; }
        public static List<Course> Courses { get; set; }        
    }
}
