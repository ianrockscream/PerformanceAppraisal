using System;
using System.Collections.Generic;

namespace PerformanceAppraisal.Entities.model
{
    public partial class Developmentplan
    {
        public int Id { get; set; }
        public long Performanceappraisalid { get; set; }
        public string Plan { get; set; }
        public string Methods { get; set; }
        public string Strengtharea { get; set; }
        public string Developmentarea { get; set; }
        public DateTime? Createdate { get; set; }
        public DateTime? Updatedate { get; set; }

        public virtual Performanceappraisal Performanceappraisal { get; set; }
    }
}
