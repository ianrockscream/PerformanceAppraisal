using System;
using System.Collections.Generic;

namespace PerformanceAppraisal.Entities.model
{
    public partial class Userlog
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public DateTime? Createdate { get; set; }
    }
}
