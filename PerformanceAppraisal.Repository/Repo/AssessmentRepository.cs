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
    public class AssessmentRepository
    {
        public perfappraisalContext _context;
        public AssessmentRepository()
        {
            this._context = new perfappraisalContext();
        }
        public Performanceappraisal GetPerfAppById(int id)
        {
            return _context.Performanceappraisal
                .Include(x => x.Businessobjective)
                .Include(x => x.Developmentplan)
                .Include(x => x.Documenthistory)
                .Include(x => x.Employee)
                .Include(x => x.Globalbehavior)
                .Include(x => x.Mobility)
                .Include(x => x.Status)
                .FirstOrDefault(x => x.Id == id);
        }
        public IQueryable<Performanceappraisal> GetPerfAppByEmployeeId(int employeeId)
        {
            return _context.Performanceappraisal
                .Include(x => x.Businessobjective)
                .Include(x => x.Developmentplan)
                .Include(x => x.Documenthistory)
                .Include(x => x.Employee)
                .Include(x => x.Globalbehavior)
                .Include(x => x.Mobility)
                .Include(x => x.Status)
                .Where(x => x.Employeeid == employeeId);
        }
        public IQueryable<Performanceappraisal> GetPerfAppByYear(int year)
        {
            return _context.Performanceappraisal
               .Include(x => x.Businessobjective)
               .Include(x => x.Developmentplan)
               .Include(x => x.Documenthistory)
               .Include(x => x.Employee)
               .Include(x => x.Globalbehavior)
               .Include(x => x.Mobility)
               .Include(x => x.Status)
               .Where(x => x.Createdate.Value.Year == year);
        }
        public Performanceappraisal CreateAssessment(AssessmentModels model)
        {
            Employee employee = _context.Employee.FirstOrDefault(x => x.Id == model.EmployeeId);
            Mobilitycode mobility = new Mobilitycode();
            Performanceappraisal perfApp = new Performanceappraisal();
            perfApp.Bodescriptivescore = model.BODescriptiveScore;
            perfApp.Bonumericscore = model.BONumericalScore;
            perfApp.Careeraspirationcomment = model.CareerAspirationComment;
            perfApp.Createdate = DateTime.Now;
            perfApp.Employee = employee;
            perfApp.Employeeid = model.EmployeeId;
            perfApp.Employeecomment = model.EmployeeComment;
            perfApp.Gbdescriptivescore = model.GBDescriptiveScore;
            perfApp.Gbnumericscore = model.GBNumericalScore;
            perfApp.Managercomment = model.ManagerComment;
            if(model.submit)
            {
                Statuscode status = _context.Statuscode.FirstOrDefault(x => x.Description == "SUBMITTED");
                if (status != null)
                {
                    perfApp.Status = status;
                    perfApp.Statusid = status.Id;
                }
                else
                {
                    status = _context.Statuscode.FirstOrDefault(x => x.Description == "PROGRESS");
                    perfApp.Status = status;
                    perfApp.Statusid = status.Id;
                }
            }
            else
            {
                Statuscode status = _context.Statuscode.FirstOrDefault(x => x.Description == "PROGRESS");
                perfApp.Status = status;
                perfApp.Statusid = status.Id;
            }
            if (!string.IsNullOrEmpty(model.MobilityStatusDesc))
            {
                mobility = _context.Mobilitycode.FirstOrDefault(x => x.Id == 2);
                perfApp.Mobility = mobility;
                perfApp.MobilityId = 2;
                perfApp.Mobilitydesc = model.MobilityStatusDesc;
            }
            else
                perfApp.MobilityId = model.MobilityStatusId;
            perfApp.Overalldescriptivescore = model.OverallDescriptiveScore;
            perfApp.Overallnumericscore = model.OverallNumericalScore;
            perfApp.Statusid = 1; // 1.Progress 2.Submitted 3.Process 4.Finish
            perfApp._2ndlvlmanagercomment = model.SecondLevelManagerComment;
            //_context.Performanceappraisal.Add(perfApp);
            //this.SaveChange();

            List<Businessobjective> BOList = new List<Businessobjective>();
            for(int i = 0; i<= model.BODescription.Count; i++)
            {
                Businessobjective bo = new Businessobjective();
                bo.Description = model.BODescription.ElementAt(i);
                bo.Employeescore = string.IsNullOrEmpty(model.BOEmployeeScore.ElementAt(i).ToString()) ? 0 : model.BOEmployeeScore.ElementAt(i);
                bo.Goalachievement = string.IsNullOrEmpty(model.BOGoals.ElementAt(i)) ? "" : model.BOGoals.ElementAt(i);
                bo.Weight = string.IsNullOrEmpty(model.BOWeight.ElementAt(i).ToString()) ? 0 : model.BOWeight.ElementAt(i);
                //bo.Performanceappraisalid = perfApp.Id;
                bo.Performanceappraisal = perfApp;
                BOList.Add(bo);
                perfApp.Businessobjective.Add(bo);
            }
            //_context.Businessobjective.AddRange(BOList);
            //this.SaveChange();

            List<Globalbehavior> GBList = new List<Globalbehavior>();
            for (int i = 0; i <= model.GBExpectedBehavior.Count; i++)
            {
                Globalbehavior gb = new Globalbehavior();
                gb.Createdate = DateTime.Now;
                gb.Demonstratedbehavior = string.IsNullOrEmpty(model.GBDemonstatedBehavior.ElementAt(i)) ? "" : model.GBDemonstatedBehavior.ElementAt(i);
                gb.Employeescore = string.IsNullOrEmpty(model.GBEmployeeScore.ElementAt(i).ToString()) ? 0 : model.GBEmployeeScore.ElementAt(i);
                gb.Expectedbehavior = string.IsNullOrEmpty(model.GBExpectedBehavior.ElementAt(i)) ? "" : model.GBExpectedBehavior.ElementAt(i);
                gb.Managerscore = string.IsNullOrEmpty(model.GBManagerScore.ElementAt(i).ToString()) ? 0 : model.GBManagerScore.ElementAt(i);
                gb.Performanceappraisal = perfApp;
                //gb.Performanceappraisalid = perfApp.Id;
                GBList.Add(gb);
                perfApp.Globalbehavior.Add(gb);
            }
            //_context.Globalbehavior.AddRange(GBList);
            //this.SaveChange();

            Developmentplan DP = new Developmentplan();
            DP.Performanceappraisalid = perfApp.Id;
            DP.Createdate = DateTime.Now;
            DP.Developmentarea = model.DPDevelopmentArea;
            DP.Methods = model.DPMethods;
            DP.Performanceappraisal = perfApp;
            DP.Plan = model.DPPlan;
            DP.Strengtharea = model.DPStrengthArea;
            perfApp.Developmentplan.Add(DP);
            //_context.Developmentplan.Add(DP);
            //this.SaveChange();
            _context.Performanceappraisal.Add(perfApp);
            this.SaveChange();

            return perfApp;

        }
        public void SaveChange()
        {
            _context.SaveChanges();
        }
    }
}
