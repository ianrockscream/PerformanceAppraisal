using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using PerformanceAppraisal.Entities;
using PerformanceAppraisal.Entities.model;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using PerformanceAppraisal.Repository.Models;

namespace PerformanceAppraisal.Repository.Repo
{
    public class SubDeparmentRepository
    {
        public perfappraisalContext _context;
        public SubDeparmentRepository()
        {
            this._context = new perfappraisalContext();
        }
        public Subdepartment GetSubdepartmentById(int id)
        {
            return _context.Subdepartment.FirstOrDefault(x => x.Id == id);
        }
        public List<Subdepartment> GetSubdepartments()
        {
            return _context.Subdepartment.ToList();
        }
        public List<Subdepartment> GetSubdepartmentsByDepartmentId(int departmentId)
        {
            return _context.Subdepartment.Where(x => x.Departmentid == departmentId).ToList();
        }
        public Subdepartment RegisterSubdepartment(GeneralModels model)
        {
            Department department = _context.Department.FirstOrDefault(x => x.Id == model.DepartmentId);
            Subdepartment subDep = new Subdepartment();
            subDep.Createdate = DateTime.Now;
            subDep.Departmentid = model.DepartmentId;
            subDep.Description = model.Description;
            subDep.Name = model.Name;
            if (department != null)
                subDep.Department = department;

            _context.Subdepartment.Add(subDep);
            this.SaveChanges();
            return subDep;
        }
        public Subdepartment UpdateSubdeparment(GeneralModels model)
        {
            Subdepartment subDep = _context.Subdepartment.FirstOrDefault(x => x.Id == model.Id);
            Department department = _context.Department.FirstOrDefault(x => x.Id == model.DepartmentId);
            if (subDep != null)
            {
                subDep.Description = model.Description;
                subDep.Name = model.Name;
                subDep.Updatedate = DateTime.Now;
                if (department != null)
                {
                    subDep.Department = department;
                    subDep.Departmentid = model.DepartmentId;
                }
                this.SaveChanges();
                return subDep;
            }
            else
                return null;
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
