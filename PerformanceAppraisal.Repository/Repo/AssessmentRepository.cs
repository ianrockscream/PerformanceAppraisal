using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using PerformanceAppraisal.Entities;
using PerformanceAppraisal.Entities.model;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

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
        public IQueryable<Performanceappraisal> GetPerformanceAppraisalsByEmployeeId(int employeeId)
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
    }
}
