using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityMS.Models
{
    public class ClassSchedule
    {
        public int Id { get; set; }
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
        public string Schedule { get; set; }
    }
}