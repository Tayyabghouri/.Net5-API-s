using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace CoreAPI.Models
{
    public partial class Department
    {
        public Department()
        {
            Employees = new HashSet<Employee>();
        }
        public int DeptId { get; set; }

        [Required(ErrorMessage ="Department name is required!")]
        public string DeptName { get; set; }

        [Required]
        public string DeptDescription { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
