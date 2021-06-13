using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolAPI.Models
{
    public class Grade
    {
        public int gradeID { get; set; }
        public int studentID { get; set; }
        public int subjectID { get; set; }
        public int grade { get; set; }
    }
}
