using System;
using System.Collections.Generic;
using System.Text;

namespace CoursesOnDemand.Domain
{
    public class User
    {
        public Nullable<long> Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
    }

}
