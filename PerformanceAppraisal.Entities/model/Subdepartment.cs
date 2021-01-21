using System;
using System.Collections.Generic;

namespace PerformanceAppraisal.Entities.model
{
    public partial class Subdepartment
    {
        public Subdepartment()
        {
            Employee = new HashSet<Employee>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Departmentid { get; set; }
        public DateTime? Createdate { get; set; }
        public DateTime? Updatedate { get; set; }

        public virtual Department Department { get; set; }
        public virtual ICollection<Employee> Employee { get; set; }
    }
}
