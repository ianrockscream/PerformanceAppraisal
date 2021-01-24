using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using PerformanceAppraisal.Entities.model;
using PerformanceAppraisal.Models;
using PerformanceAppraisal.Repository.Models;
using PerformanceAppraisal.Repository.Repo;

namespace PerformanceAppraisal.Controllers
{
    public class BaseController : Controller
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string ESMJson = HttpContext.Session.GetString("ESM");
            if (string.IsNullOrEmpty(ESMJson))
            {
                filterContext.Result = new RedirectToActionResult("Login", "Account", new { returnUrl = HttpContext.Request.Path + HttpContext.Request.QueryString } );
                return;
            }
            EmployeeSessionModel ESM = JsonConvert.DeserializeObject<EmployeeSessionModel>(ESMJson);
            if (string.IsNullOrEmpty(ESM.EmployeeId))
            {
                filterContext.Result = new RedirectToActionResult("Login", "Account", new { returnUrl = HttpContext.Request.Path + HttpContext.Request.QueryString });
                return;
            }
            if(!ESM.isAdministrator)
            {
                ViewBag.Controller = ControllerContext.RouteData.Values["Controller"];
                ViewBag.employeeName = ESM.Name;
                ViewBag.email = ESM.Email;
                ViewBag.position = ESM.Position + " " + ESM.Department + " " + ESM.SubDepartment;
                ViewBag.employeeId = ESM.EmployeeId;
                ViewBag.level = ESM.Level;
            }
            else
            {
                ViewBag.Controller = ControllerContext.RouteData.Values["Controller"];
                ViewBag.employeeName = ESM.Name;
                ViewBag.email = ESM.Email;
                ViewBag.position = ESM.Position;
                ViewBag.employeeId = ESM.EmployeeId;
                ViewBag.isAdministrator = true;
            }
            base.OnActionExecuting(filterContext);            
        }
    }
}
