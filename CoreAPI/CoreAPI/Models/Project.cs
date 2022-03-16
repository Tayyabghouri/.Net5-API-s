using System;
using System.Collections.Generic;

#nullable disable

namespace CoreAPI.Models
{
    public partial class Project
    {
        public int PId { get; set; }
        public string PName { get; set; }
        public string PDescription { get; set; }
        public int? MId { get; set; }

        public virtual Module MIdNavigation { get; set; }
    }
}
