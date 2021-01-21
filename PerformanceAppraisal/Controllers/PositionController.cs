using Microsoft.AspNetCore.Mvc;
using PerformanceAppraisal.Entities.model;
using PerformanceAppraisal.Repository.Helper;
using PerformanceAppraisal.Repository.Models;
using PerformanceAppraisal.Repository.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PerformanceAppraisal.Controllers
{
    public class PositionController : Controller
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
                PositionRepository posRepo = new PositionRepository();
                Position position = posRepo.RegisterPosition(model);
                Helper.Alert("Register Position Success");
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                Helper.Alert(ex.Message);
                return View(model);
            }
        }
        public IActionResult Edit(int Id)
        {
            PositionRepository posRepo = new PositionRepository();
            Position position = posRepo.GetPositionById(Id);
            if (position != null)
            {
                GeneralModels model = new GeneralModels();
                model.Id = position.Id;
                model.Description = position.Description;
                model.Name = position.Name;
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
                PositionRepository posRepo = new PositionRepository();
                Position position = posRepo.UpdatePosition(model);
                if (position == null)
                    throw new Exception("Position not found.");
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
