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
    public class PositionRepository
    {
        public perfappraisalContext _context;
        public PositionRepository()
        {
            this._context = new perfappraisalContext();
        }
        public Position GetPositionById(int id)
        {
            return _context.Position.FirstOrDefault(x => x.Id == id);
        }
        public List<Position> GetPositions()
        {
            return _context.Position.ToList();
        }
        public Position RegisterPosition(GeneralModels model)
        {
            Position position = new Position();
            position.Createdate = DateTime.Now;
            position.Description = model.Description;
            position.Name = model.Name;
            _context.Position.Add(position);
            this.SaveChanges();
            return position;
        }
        public Position UpdatePosition(GeneralModels model)
        {
            Position position = this.GetPositionById(model.Id);
            if (position != null)
            {
                position.Description = model.Description;
                position.Name = model.Name;
                position.Updatedate = DateTime.Now;
                this.SaveChanges();
                return position;
            }
            else
                return null;
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
