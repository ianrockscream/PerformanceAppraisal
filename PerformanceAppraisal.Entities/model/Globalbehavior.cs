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
        public string Employeescore { get; set; }
        public string Managerscore { get; set; }
        public DateTime? Createdate { get; set; }

        public virtual Performanceappraisal Performanceappraisal { get; set; }
    }
}
