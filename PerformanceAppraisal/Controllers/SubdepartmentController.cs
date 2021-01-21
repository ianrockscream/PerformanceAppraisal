using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PerformanceAppraisal.Entities.model;
using PerformanceAppraisal.Repository.Helper;
using PerformanceAppraisal.Repository.Models;
using PerformanceAppraisal.Repository.Repo;

namespace PerformanceAppraisal.Controllers
{
    public class SubdepartmentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(GeneralModels model)
        {
            try
            {
                SubDeparmentRepository subdepRepo = new SubDeparmentRepository();
                Subdepartment subDept = subdepRepo.RegisterSubdepartment(model);
                Helper.Alert("Register Subdepartment Success");
                return RedirectToAction("Index", "Department");
            }
            catch (Exception ex)
            {
                Helper.Alert(ex.Message);
                return View(model);
            }
        }
        public IActionResult Edit(int Id)
        {
            SubDeparmentRepository subDeptRepo = new SubDeparmentRepository();
            Subdepartment subDept = subDeptRepo.GetSubdepartmentById(Id);
            if (subDept != null)
            {
                GeneralModels model = new GeneralModels();
                model.Id = subDept.Id;
                model.Description = subDept.Description;
                model.Name = subDept.Name;
                return View(model);
            }
            else
                return RedirectToAction("Register");
        }
        [HttpPost]
        public IActionResult Edit(GeneralModels model)
        {
            try
            {
                SubDeparmentRepository subDeparmentRepository = new SubDeparmentRepository();
                Subdepartment subdepartment = subDeparmentRepository.UpdateSubdeparment(model);
                if (subdepartment == null)
                    throw new Exception("Subdepartment not found.");
                else
                    return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                Helper.Alert(ex.Message);
                return View(model);
            }
        }
    }
}
