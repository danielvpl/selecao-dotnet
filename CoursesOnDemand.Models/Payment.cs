using System;
using System.Collections.Generic;
using System.Text;

namespace CoursesOnDemand.Domain
{
    public class Payment
    {
        public long Id { get; set; }
        public DateTime DataTime { get; set; }
        public float Valor { get; set; }
    }
}
