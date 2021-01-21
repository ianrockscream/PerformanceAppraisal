using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PerformanceAppraisal.Entities.model;
using PerformanceAppraisal.Repository.Repo;
using X.PagedList;

namespace PerformanceAppraisal.ViewComponents
{
    public class SubdepartmentViewComponents : ViewComponent
    {
        public IViewComponentResult Invoke(int page = 1, int pageSize = 20)
        {
            SubDeparmentRepository subdepartmentRepo = new SubDeparmentRepository();
            List<Subdepartment> subdepartments = subdepartmentRepo.GetSubdepartments();
            IPagedList<Subdepartment> subdepartmentPaged = subdepartments.OrderBy(x => x.Name).ToPagedList(page, pageSize);
            int ps = page * pageSize;
            int datacount = subdepartments.Count();
            ViewBag.showEntriesLabel = "Showing " + ((page == 1 ? 1 : ((page - 1) * pageSize) + 1)) + " to " + (ps > datacount ? datacount : ps) + " of " + datacount + " entries.";

            return View(subdepartmentPaged);
        }
    }
}
