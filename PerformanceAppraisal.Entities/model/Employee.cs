using System;
using System.Collections.Generic;

namespace PerformanceAppraisal.Entities.model
{
    public partial class Employee
    {
        public Employee()
        {
            Documenthistory = new HashSet<Documenthistory>();
            Performanceappraisal = new HashSet<Performanceappraisal>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Nik { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public int? PositionId { get; set; }
        public int? DepartmentId { get; set; }
        public int? SubdepartmentId { get; set; }
        public DateTime? Createdate { get; set; }
        public DateTime? Updatedate { get; set; }

        public virtual Department Department { get; set; }
        public virtual Position Position { get; set; }
        public virtual Subdepartment Subdepartment { get; set; }
        public virtual ICollection<Documenthistory> Documenthistory { get; set; }
        public virtual ICollection<Performanceappraisal> Performanceappraisal { get; set; }
    }
}
