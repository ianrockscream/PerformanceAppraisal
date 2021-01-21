using System;
using System.Collections.Generic;

namespace PerformanceAppraisal.Entities.model
{
    public partial class Mobilitycode
    {
        public Mobilitycode()
        {
            Performanceappraisal = new HashSet<Performanceappraisal>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public DateTime? Createdate { get; set; }
        public DateTime? Updatedate { get; set; }

        public virtual ICollection<Performanceappraisal> Performanceappraisal { get; set; }
    }
}
