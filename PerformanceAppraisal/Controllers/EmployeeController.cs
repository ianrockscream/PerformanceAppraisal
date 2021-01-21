using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using PerformanceAppraisal.Entities.model;
using PerformanceAppraisal.Models;
using PerformanceAppraisal.Repository.Repo;
using PerformanceAppraisal.Repository.Helper;
using PerformanceAppraisal.Repository.Models;

namespace PerformanceAppraisal.Controllers
{
    public class EmployeeController : BaseController
    {
        public IActionResult Profile(int Id)
        {
            string ESMJson = HttpContext.Session.GetString("ESM");
            EmployeeSessionModel ESM = new EmployeeSessionModel();
            EmployeeRepository employeeRepo = new EmployeeRepository();
            if(!string.IsNullOrEmpty(ESMJson))
            {
                ESM = JsonConvert.DeserializeObject<EmployeeSessionModel>(ESMJson);
                Employee employee = employeeRepo.GetEmployeeById(Convert.ToInt32(ESM.EmployeeId));
                EmployeeModels eModel = new EmployeeModels();
                eModel.active = true;
                eModel.Department = employee.Department.Name;
                eModel.DepartmentId = (int)employee.DepartmentId;
                eModel.Email = employee.Email;
                eModel.Id = employee.Id;
                eModel.Name = ESM.Name;
                eModel.NIK = ESM.NIK;
                eModel.Phone = employee.Phone;
                eModel.Position = ESM.Position;
                eModel.PositionId = Convert.ToInt32(ESM.PositionId);
                eModel.Subdepartment = ESM.SubDepartment;
                eModel.SubDepartmentId = Convert.ToInt32(ESM.SubDeparmentId);
                return View(eModel);
            }
            else
                return View(new EmployeeModels());
        }
        public IActionResult Index()
        {
            ViewBag.Controller = "Employee";
            return View();
        }
        public IActionResult Register()
        {
            DepartmentRepository deptRepo = new DepartmentRepository();
            SubDeparmentRepository subDeptRepo = new SubDeparmentRepository();
            PositionRepository posRepo = new PositionRepository();

            ViewBag.PositionList = posRepo.GetPositions();
            ViewBag.DepartmentList = deptRepo.GetDepartments();
            ViewBag.SubDepartmentList = subDeptRepo.GetSubdepartments();
            return View();
        }
        [HttpPost]
        public IActionResult Register(EmployeeModels model)
        {
            return View();
        }
        public IActionResult Edit(int Id)
        {
            EmployeeRepository employeeRepo = new EmployeeRepository();
            Employee employee = employeeRepo.GetEmployeeById(Id);
            return View();
        }
        public IActionResult Edit(EmployeeModels model)
        {
            if (model.Id != 0)
            {
                EmployeeRepository employeeRepo = new EmployeeRepository();
                Employee employee = employeeRepo.GetEmployeeById(model.Id);
                if (employee != null)
                {
                    employee.DepartmentId = model.DepartmentId;
                    employee.Email = model.Email;
                    employee.Name = model.Name;
                    employee.Nik = model.NIK;
                    employee.Phone = model.Phone;
                    employee.PositionId = model.PositionId;
                    employee.SubdepartmentId = model.SubDepartmentId;
                    employee.Updatedate = DateTime.Now;
                    employeeRepo.UpdateEmployee();
                    return RedirectToAction("Manage", "Employee");
                }
                else
                {
                    return View(model);
                }
            }
            else
                return View(model);
        }
        public IActionResult View(int Id)
        {
            return View();
        }
        public IActionResult GetSubdepartment(string DepartmentId)
        {
            int deptId = Convert.ToInt32(DepartmentId);
            SubDeparmentRepository subDeptRepo = new SubDeparmentRepository();
            List<Subdepartment> subDeptList = subDeptRepo.GetSubdepartmentsByDepartmentId(deptId);
            List<subdepartmentreg> data = new List<subdepartmentreg>();
            foreach (var item in subDeptList)
            {
                subdepartmentreg subdeptreg = new subdepartmentreg();
                subdeptreg.Name = item.Name;
                subdeptreg.SubdepartmentId = item.Id.ToString();
                data.Add(subdeptreg);
            }
            string jsonData = JsonConvert.SerializeObject(data);
            return Json(jsonData);
        }
        public class subdepartmentreg
        {
            public string SubdepartmentId { get; set; }
            public string Name { get; set; }

        }
    }
}
