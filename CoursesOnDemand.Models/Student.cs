﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CoursesOnDemand.Domain
{
    public class Student : User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public String Email { get; set; }
        public String Phone { get; set; }
        public CreditCard CreditCard { get; set; }
        public Course Course { get; set; }
        public IList<Payment> Payments { get; set; }        
    }
}
