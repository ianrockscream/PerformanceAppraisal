using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using PerformanceAppraisal.Entities.model;
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
        public IActionResult IndividualAssessment(AssessmentModels model = null)
        {
            string ESMJson = HttpContext.Session.GetString("ESM");
            EmployeeSessionModel ESM = JsonConvert.DeserializeObject<EmployeeSessionModel>(ESMJson);

            if (!string.IsNullOrEmpty(ESM.EmployeeId))
            {
                if(model.DocumentId != 0)
                {
                    model = this.InitModel(model.DocumentId);
                    model.BODescription = new List<string>();
                    AssessmentRepository assesmentRepo = new AssessmentRepository();
                    Performanceappraisal assessment = assesmentRepo.GetPerfAppById(model.DocumentId);
                    foreach(var item in assessment.Businessobjective)
                    {
                        model.BODescription.Add(item.Description);
                        model.BOEmployeeScore.Add(item.Employeescore);
                        model.BOGoals.Add(item.Goalachievement);
                        model.BOWeight.Add(item.Weight);
                    }
                    foreach(var item in assessment.Globalbehavior)
                    {
                        model.GBDemonstatedBehavior.Add(item.Demonstratedbehavior);
                        model.GBEmployeeScore.Add(item.Employeescore);
                        model.GBExpectedBehavior.Add(item.Expectedbehavior);
                    }
                    model.BODescriptiveScore = assessment.Bodescriptivescore;
                    model.BONumericalScore = assessment.Bonumericscore;
                    model.CareerAspirationComment = assessment.Careeraspirationcomment;
                    foreach(var item in assessment.Developmentplan)
                    {
                        model.DPDevelopmentArea = item.Developmentarea;
                        model.DPMethods = item.Methods;
                        model.DPPlan = item.Plan;
                        model.DPStrengthArea = item.Strengtharea;
                    }
                    model.EmployeeComment = assessment.Employeecomment;
                    model.ManagerComment = assessment.Managercomment;
                    model.MobilityStatusId = (int)assessment.MobilityId;
                    model.MobilityStatusDesc = assessment.Mobilitydesc;
                    model.OverallDescriptiveScore = assessment.Overalldescriptivescore;
                    model.OverallNumericalScore = assessment.Overallnumericscore;
                    model.SecondLevelManagerComment = assessment._2ndlvlmanagercomment;
                    model.ESM = ESM;
                }
                else
                {
                    model = this.InitModel(0);
                    model.ESM = ESM;
                }
            }
            else
            {
                model = this.InitModel(0);
                model.ESM = ESM;
            }

            DepartmentRepository deptRepo = new DepartmentRepository();
            SubDeparmentRepository subDeptRepo = new SubDeparmentRepository();
            ViewBag.departmentId = ESM.DepartmentId;
            ViewBag.subdepartmentId = ESM.SubDeparmentId;
            ViewBag.Department = deptRepo.GetDepartments();
            ViewBag.SubDepartment = subDeptRepo.GetSubdepartments();

            return View(model);
        }
        [HttpPost]
        public IActionResult SaveFormAssessment(AssessmentModels model)
        {
            AssessmentRepository repo = new AssessmentRepository();
            try
            {
                model.EmployeeId = Convert.ToInt32(ViewBag.employeeId);
                repo.CreateAssessment(model);

                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                return RedirectToAction("IndividualAssessment", model);
            }
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
        private AssessmentModels InitModel(int documentId)
        {
            AssessmentModels models = new AssessmentModels();
            models.DocumentId = documentId;
            models.BODescription = new List<string>();
            models.BOEmployeeScore = new List<string>();
            models.BOGoals = new List<string>();
            models.BOWeight = new List<int>();
            models.GBDemonstatedBehavior = new List<string>();
            models.GBExpectedBehavior = new List<string>();
            models.GBEmployeeScore = new List<string>();

            if(documentId == 0)
            {
                for(int i = 0; i<=4; i++)
                {
                    models.BODescription.Add(string.Empty);
                    models.BOEmployeeScore.Add(string.Empty);
                    models.BOGoals.Add(string.Empty);
                    models.BOWeight.Add(0);
                    if(i < 4)
                    {
                        models.GBDemonstatedBehavior.Add(string.Empty);
                        models.GBExpectedBehavior.Add(string.Empty);
                        models.GBEmployeeScore.Add(string.Empty);
                    }
                }

            }
            return models;
        }
    }
}
