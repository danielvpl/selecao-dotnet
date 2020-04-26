using System;
using System.Collections.Generic;
using System.Text;

namespace CoursesOnDemand.Domain
{
    public class Course
    {
        public Nullable<int> Id { get; set; }
        public String Title { get; set; }
        public String Description { get; set; }
    }
}
