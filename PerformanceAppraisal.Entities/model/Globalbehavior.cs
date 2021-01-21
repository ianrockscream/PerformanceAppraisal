using System;
using System.Collections.Generic;

namespace PerformanceAppraisal.Entities.model
{
    public partial class Globalbehavior
    {
        public int Id { get; set; }
        public long Performanceappraisalid { get; set; }
        public string Expectedbehavior { get; set; }
        public string Demonstratedbehavior { get; set; }
        public int? Employeescore { get; set; }
        public int? Managerscore { get; set; }
        public DateTime? Createdate { get; set; }

        public virtual Performanceappraisal Performanceappraisal { get; set; }
    }
}
