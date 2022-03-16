using System;
using System.Collections.Generic;

#nullable disable

namespace CoreAPI.Models
{
    public partial class Student
    {
        public Student()
        {
            StudentCourses = new HashSet<StudentCourse>();
        }

        public int SId { get; set; }
        public string SName { get; set; }

        public virtual ICollection<StudentCourse> StudentCourses { get; set; }
    }
}
