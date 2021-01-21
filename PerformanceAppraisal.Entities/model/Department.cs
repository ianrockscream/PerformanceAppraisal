using System;
using System.Collections.Generic;

namespace PerformanceAppraisal.Entities.model
{
    public partial class Department
    {
        public Department()
        {
            Employee = new HashSet<Employee>();
            Subdepartment = new HashSet<Subdepartment>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? Createdate { get; set; }
        public DateTime? Updatedate { get; set; }

        public virtual ICollection<Employee> Employee { get; set; }
        public virtual ICollection<Subdepartment> Subdepartment { get; set; }
    }
}
