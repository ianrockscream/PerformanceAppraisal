using System;
using System.Collections.Generic;

namespace PerformanceAppraisal.Entities.model
{
    public partial class Performanceappraisal
    {
        public Performanceappraisal()
        {
            Businessobjective = new HashSet<Businessobjective>();
            Developmentplan = new HashSet<Developmentplan>();
            Documenthistory = new HashSet<Documenthistory>();
            Globalbehavior = new HashSet<Globalbehavior>();
        }

        public long Id { get; set; }
        public int Employeeid { get; set; }
        public int? Bonumericscore { get; set; }
        public string Bodescriptivescore { get; set; }
        public int? Gbnumericscore { get; set; }
        public string Gbdescriptivescore { get; set; }
        public int? Overallnumericscore { get; set; }
        public string Overalldescriptivescore { get; set; }
        public int? MobilityId { get; set; }
        public string Mobilitydesc { get; set; }
        public string Careeraspirationcomment { get; set; }
        public string Employeecomment { get; set; }
        public string Managercomment { get; set; }
        public string _2ndlvlmanagercomment { get; set; }
        public int? Statusid { get; set; }
        public DateTime? Createdate { get; set; }
        public DateTime? Updatedate { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Mobilitycode Mobility { get; set; }
        public virtual Statuscode Status { get; set; }
        public virtual ICollection<Businessobjective> Businessobjective { get; set; }
        public virtual ICollection<Developmentplan> Developmentplan { get; set; }
        public virtual ICollection<Documenthistory> Documenthistory { get; set; }
        public virtual ICollection<Globalbehavior> Globalbehavior { get; set; }
    }
}
