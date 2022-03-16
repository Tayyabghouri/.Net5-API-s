using System;
using System.Collections.Generic;

#nullable disable

namespace CoreAPI.Models
{
    public partial class Employee
    {
        public Employee()
        {
            WorkItems = new HashSet<WorkItem>();
        }

        public int EId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public int? Salary { get; set; }
        public int? DepartmentId { get; set; }

        public virtual Department Department { get; set; }
        public virtual ICollection<WorkItem> WorkItems { get; set; }
    }
}
