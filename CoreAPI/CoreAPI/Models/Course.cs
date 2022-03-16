using System;
using System.Collections.Generic;

#nullable disable

namespace CoreAPI.Models
{
    public partial class Course
    {
        public Course()
        {
            StudentCourses = new HashSet<StudentCourse>();
        }

        public int CId { get; set; }
        public string CName { get; set; }
        //without virtual keyword it will return null like "Course.StudentCourses"
        public virtual ICollection<StudentCourse> StudentCourses { get; set; }
    }
}
