using System;
using System.Collections.Generic;

#nullable disable

namespace CoreAPI.Models
{
    public partial class StudentCourse
    {
        public int ScId { get; set; }
        public int? SId { get; set; }
        public int? CId { get; set; }

        public virtual Course CIdNavigation { get; set; }
        public virtual Student SIdNavigation { get; set; }
    }
}
