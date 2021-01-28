using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using PerformanceAppraisal.Models;
using PerformanceAppraisal.Repository.Models;
using PerformanceAppraisal.Repository.Repo;

namespace PerformanceAppraisal.Controllers
{
    public class AssessmentController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult IndividualAssessment()
        {
            string ESMJson = HttpContext.Session.GetString("ESM");
            EmployeeSessionModel ESM = JsonConvert.DeserializeObject<EmployeeSessionModel>(ESMJson);

            DepartmentRepository deptRepo = new DepartmentRepository();
            SubDeparmentRepository subDeptRepo = new SubDeparmentRepository();
            ViewBag.departmentId = ESM.DepartmentId;
            ViewBag.subdepartmentId = ESM.SubDeparmentId;
            ViewBag.Department = deptRepo.GetDepartments();
            ViewBag.SubDepartment = subDeptRepo.GetSubdepartments();

            return View(ESM);
        }
        [HttpPost]
        public IActionResult SaveFormAssessment(AssessmentModels model)
        {
            return View();
        }
        public IActionResult SuperiorAssessment()
        {
            string ESMJson = HttpContext.Session.GetString("ESM");
            EmployeeSessionModel ESM = JsonConvert.DeserializeObject<EmployeeSessionModel>(ESMJson);

            DepartmentRepository deptRepo = new DepartmentRepository();
            SubDeparmentRepository subDeptRepo = new SubDeparmentRepository();

            ViewBag.Department = deptRepo.GetDepartments();
            ViewBag.SubDepartment = subDeptRepo.GetSubdepartments();

            return View(ESM);
        }
        public IActionResult Approval()
        {
            string ESMJson = HttpContext.Session.GetString("ESM");
            EmployeeSessionModel ESM = JsonConvert.DeserializeObject<EmployeeSessionModel>(ESMJson);
            return View(ESM);
        }
    }
}
