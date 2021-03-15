using ACFIP.Data.Dtos.ViolationType;
using System;
using System.Collections.Generic;
using System.Text;

namespace ACFIP.Data.Dtos.ViolationCase
{
    public class ViolationReport
    {
        public ViolationReport()
        {
            TypeReports = new List<TypeReport>();
        }
        public int Month { get; set; }
        public int NumberOfViolations { get; set; }
        public List<TypeReport> TypeReports { get; set; }
    }
}
