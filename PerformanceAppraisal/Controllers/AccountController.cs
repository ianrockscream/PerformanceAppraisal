using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PerformanceAppraisal.Entities.model;
using PerformanceAppraisal.Models;
using PerformanceAppraisal.Repository.Repo;
using PerformanceAppraisal.Repository.Helper;
using Microsoft.AspNetCore.Session;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using PerformanceAppraisal.Repository.Models;

namespace PerformanceAppraisal.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginModels model, string returnUrl)
        {
            EmployeeRepository employeeRepo = new EmployeeRepository();
            Employee employee = employeeRepo.GetEmployeeByNIKAndPassword(model.NIK, Helper.HashSha256(model.Password));
            if (employee != null)
            {
                EmployeeSessionModel ESM = new EmployeeSessionModel();
                ESM.Department = employee.Department.Name;
                ESM.DepartmentId = employee.DepartmentId.ToString();
                ESM.EmployeeId = employee.Id.ToString();
                ESM.Email = employee.Email;
                ESM.Name = employee.Name;
                ESM.NIK = employee.Nik;
                ESM.Position = employee.Position.Name;
                ESM.PositionId = employee.PositionId.ToString();
                ESM.SubDepartment = employee.Subdepartment.Name;
                ESM.SubDeparmentId = employee.SubdepartmentId.ToString();

                string ESMJson = JsonConvert.SerializeObject(ESM);
                HttpContext.Session.SetString("ESM", ESMJson);
                if (!string.IsNullOrEmpty(returnUrl))
                    return Redirect(returnUrl);
                else
                    return RedirectToAction("Profile", "Employee", new { Id = ESM.EmployeeId});
            }
            else
            {
                AdminRepository adminRepo = new AdminRepository();
                Admin admin = adminRepo.GetAdminByLoginNameAndPassword(model.NIK, Helper.HashSha256(model.Password));
                if(admin == null)
                {
                    TempData["alert"] = Helper.Alert("NIK atau password salah.");
                    return View(model);
                }
                else
                {
                    EmployeeSessionModel esm = new EmployeeSessionModel();
                    esm.Name = admin.Name;
                    esm.NIK = admin.Loginname;
                    esm.Position = "Administrator";
                    esm.EmployeeId = admin.Id.ToString();
                    esm.Email = admin.Email;
                    esm.isAdministrator = true;
                    return RedirectToAction("Index", "Home");
                }
            }
        }
        
    }
}
