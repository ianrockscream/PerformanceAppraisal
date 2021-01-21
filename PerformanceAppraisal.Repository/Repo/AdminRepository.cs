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
    public class AdminRepository
    {
        public perfappraisalContext _context;
        public AdminRepository()
        {
            this._context = new perfappraisalContext();
        }
        public Admin GetAdminById(int id)
        {
            return _context.Admin.FirstOrDefault(x => x.Id == id);
        }
        public Admin GetAdminByLoginNameAndPassword(string loginName, string password)
        {
            return _context.Admin.FirstOrDefault(x => x.Loginname == loginName && x.Password == password);
        }
        public List<Admin> GetAdmins()
        {
            return _context.Admin.ToList();
        }
    }
}
