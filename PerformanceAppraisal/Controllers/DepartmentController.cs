using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

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
            return View();
        }
    }
}
