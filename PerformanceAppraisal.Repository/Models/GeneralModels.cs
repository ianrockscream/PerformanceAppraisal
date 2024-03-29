﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PerformanceAppraisal.Repository.Models
{
    public class GeneralModels
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CreateDate { get; set; }
        public string UpdateDate { get; set; }
        public int DepartmentId { get; set; }
    }
}
