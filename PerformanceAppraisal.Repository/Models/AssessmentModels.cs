using System;
using System.Collections.Generic;
using System.Text;

namespace PerformanceAppraisal.Repository.Models
{
    public class AssessmentModels
    {
        public int EmployeeId { get; set; }
        public ICollection<string> BODescription { get; set; }
        public ICollection<int> BOWeight { get; set; }
        public ICollection<string> BOGoals { get; set; }
        public ICollection<int> BOEmployeeScore { get; set; }
        public ICollection<int> BOManagerScore { get; set; }
        public int BONumericalScore { get; set; }
        public string BODescriptiveScore { get; set; }
        public ICollection<int> GBWeight { get; set; }
        public ICollection<string> GBExpectedBehavior { get; set; }
        public ICollection<string> GBDemonstatedBehavior { get; set; }
        public ICollection<int> GBEmployeeScore { get; set; }
        public ICollection<int> GBManagerScore { get; set; }
        public int GBNumericalScore { get; set; }
        public string GBDescriptiveScore { get; set; }
        public int OverallNumericalScore { get; set; }
        public string OverallDescriptiveScore { get; set; }
        public int MobilityStatusId { get; set; }
        public string MobilityStatusDesc { get; set; }
        public string CareerAspirationComment { get; set; }
        public string DPPlan { get; set; }
        public string DPMethods { get; set; }
        public string DPStrengthArea { get; set; }
        public string DPDevelopmentArea { get; set; }
        public string EmployeeComment { get; set; }
        public string ManagerComment { get; set; }
        public string SecondLevelManagerComment { get; set; }
        public string EmployeeApproval { get; set; }
        public string ManagerApproval { get; set; }
        public string SecondLevelManagerApproval { get; set; }
    }
    public class PerformanceAppraisalModels
    { 

    }
}
