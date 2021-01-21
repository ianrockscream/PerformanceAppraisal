using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using PerformanceAppraisal.Entities;
using PerformanceAppraisal.Entities.model;
using Microsoft.EntityFrameworkCore;

namespace PerformanceAppraisal.Repository.Repo
{
    public class EmployeeRepository
    {
        public perfappraisalContext _context;
        public EmployeeRepository()
        {
            this._context = new perfappraisalContext();
        }
        public Employee GetEmployeeById(int id)
        {
            return _context.Employee
                .Include(x => x.Position)
                .Include(x => x.Subdepartment)
                .Include(x => x.Department)
                .FirstOrDefault(x => x.Id == id);
        }
        public Employee GetEmployeeByNIKAndPassword(string nik, string password)
        {
            return _context.Employee.Include(x => x.Position)
                .Include(x => x.Subdepartment)
                .Include(x => x.Department)
                .FirstOrDefault(x => x.Nik == nik && x.Password == password);
        }
        public IQueryable<Employee> GetEmployees()
        {
            return _context.Employee
                .Include(x => x.Position)
                .Include(x => x.Subdepartment)
                .Include(x => x.Department);
        }
        public Employee RegisterNewEmployee(Employee model)
        {
            _context.Employee.Add(model);
            _context.SaveChanges();
            return model;
        }
        public void UpdateEmployee()
        {
            _context.SaveChanges();
        }
    }
}
