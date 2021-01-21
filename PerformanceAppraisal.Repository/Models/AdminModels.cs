using System;
using System.Collections.Generic;
using System.Text;

namespace PerformanceAppraisal.Repository.Models
{
    public class AdminModels
    {
        public int Id { get; set; }
        public string AdminName { get; set; }
        public string LoginName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
