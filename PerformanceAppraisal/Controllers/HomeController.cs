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
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult IndividualAssessment()
        {
            string ESMJson = HttpContext.Session.GetString("ESM");
            EmployeeSessionModel ESM = JsonConvert.DeserializeObject<EmployeeSessionModel>(ESMJson);

            DepartmentRepository deptRepo = new DepartmentRepository();
            SubDeparmentRepository subDeptRepo = new SubDeparmentRepository();

            ViewBag.Department = deptRepo.GetDepartments();
            ViewBag.SubDepartment = subDeptRepo.GetSubdepartments();

            return View(ESM);
        }
        public IActionResult SuperiorAssessment()
        {
            string ESMJson = HttpContext.Session.GetString("ESM");
            EmployeeSessionModel ESM = JsonConvert.DeserializeObject<EmployeeSessionModel>(ESMJson);

            DepartmentRepository deptRepo = new DepartmentRepository();
            SubDeparmentRepository subDeptRepo = new SubDeparmentRepository();

            ViewBag.Department = deptRepo.GetDepartments();
            ViewBag.SubDepartment = subDeptRepo.GetSubdepartments();
            ViewBag.Controller = "Home";
            return View(ESM);
        }
        public IActionResult AssessmentApproval()
        {
            string ESMJson = HttpContext.Session.GetString("ESM");
            EmployeeSessionModel ESM = JsonConvert.DeserializeObject<EmployeeSessionModel>(ESMJson);
            return View(ESM);
        }
    }
}
