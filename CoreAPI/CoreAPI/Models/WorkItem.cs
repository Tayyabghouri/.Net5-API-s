using System;
using System.Collections.Generic;

#nullable disable

namespace CoreAPI.Models
{
    public partial class WorkItem
    {
        public WorkItem()
        {
            Modules = new HashSet<Module>();
        }

        public int WId { get; set; }
        public string WName { get; set; }
        public string WDescription { get; set; }
        public int? EId { get; set; }

        public virtual Employee EIdNavigation { get; set; }
        public virtual ICollection<Module> Modules { get; set; }
    }
}
