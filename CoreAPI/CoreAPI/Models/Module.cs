using System;
using System.Collections.Generic;

#nullable disable

namespace CoreAPI.Models
{
    public partial class Module
    {
        public Module()
        {
            Projects = new HashSet<Project>();
        }

        public int MId { get; set; }
        public string MName { get; set; }
        public string MDescription { get; set; }
        public int? WId { get; set; }

        public virtual WorkItem WIdNavigation { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
    }
}
