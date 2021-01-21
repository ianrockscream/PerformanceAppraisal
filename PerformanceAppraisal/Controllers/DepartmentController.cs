using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PerformanceAppraisal.Entities.model;
using PerformanceAppraisal.Repository.Repo;

namespace PerformanceAppraisal.Controllers
{
    public class DepartmentController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        public IActionResult Edit(int Id)
        {
            return View();
        }
        public IActionResult View(int Id)
        {
            DepartmentRepository departmentRepository = new DepartmentRepository();
            Department department = departmentRepository.GetDepartmentById(Id);
            if (department != null)
                return View(department);
            else
                return RedirectToAction("Index");
        }
    }
}
