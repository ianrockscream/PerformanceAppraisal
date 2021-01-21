using System;
using System.Collections.Generic;

namespace PerformanceAppraisal.Entities.model
{
    public partial class Businessobjective
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int Weight { get; set; }
        public string Goalachievement { get; set; }
        public int? Employeescore { get; set; }
        public int? Managerscore { get; set; }
        public long Performanceappraisalid { get; set; }
        public DateTime? Createdate { get; set; }

        public virtual Performanceappraisal Performanceappraisal { get; set; }
    }
}
