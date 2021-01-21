using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using PerformanceAppraisal.Entities;
using PerformanceAppraisal.Entities.model;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace PerformanceAppraisal.Repository.Repo
{
    public class DepartmentRepository
    {
        public perfappraisalContext _context;
        public DepartmentRepository()
        {
            this._context = new perfappraisalContext();
        }
        public Department GetDepartmentById(int id)
        {
            return _context.Department.FirstOrDefault(x => x.Id == id);
        }
        public IQueryable<Department> GetDepartments()
        {
            return _context.Department.Include(x => x.Subdepartment);
        }
    }
}
