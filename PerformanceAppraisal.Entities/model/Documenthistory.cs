using System;
using System.Collections.Generic;

namespace PerformanceAppraisal.Entities.model
{
    public partial class Documenthistory
    {
        public long Id { get; set; }
        public long Performanceappraisalid { get; set; }
        public int Employeeid { get; set; }
        public string Changelog { get; set; }
        public DateTime? Createdate { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Performanceappraisal Performanceappraisal { get; set; }
    }
}
