using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolAPI.Models
{
    public class Student
    {
        public int studentID { get; set; }
        public string studentFN { get; set; }
        public string studentLN { get; set; }
        public DateTime studentDOB { get; set; }
    }
}
