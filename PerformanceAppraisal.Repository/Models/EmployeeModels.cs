using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PerformanceAppraisal.Repository.Models
{
    public class EmployeeModels
    {
        public string NIK { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public int DepartmentId { get; set; }
        public int SubDepartmentId { get; set; }
        public int PositionId { get; set; }
        public bool active { get; set; }
        public int Id { get; set; }
        public string Department { get; set; }
        public string Subdepartment { get; set; }
        public string Position { get; set; }
    }
}
