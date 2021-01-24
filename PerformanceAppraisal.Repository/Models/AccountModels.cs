using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PerformanceAppraisal.Repository.Models
{
    public class AccountModels
    {
    }
    public class LoginModels
    {
        public string NIK { get; set; }
        public string Password { get; set; }
    }
    public class EmployeeSessionModel
    {
        public string Department { get; set; }
        public string DepartmentId { get; set; }
        public string NIK { get; set; }
        public string Name { get; set; }
        public string EmployeeId { get; set; }
        public string Email { get; set; }
        public string Position { get; set; }
        public string PositionId { get; set; }
        public string SubDepartment { get; set; }
        public string SubDeparmentId { get; set; }
        public int Level { get; set; }
        public bool isAdministrator { get; set; }
    }
    public class GetSubdepartmentModel
    {
        public int departmentId { get; set; }
    }
}
