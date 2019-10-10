using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB4OLab
{
    public class Student
    {
        public string StudentId { get; set; }
        public string FullName { get; set; }
        public double Mark { get; set; }
        public int RegisterYear { get; set; }
        public DateTime BirthDate { get; set; }
        public int Age
        {
            get { return DateTime.Now.Year - BirthDate.Year; }
        }
    }
}
