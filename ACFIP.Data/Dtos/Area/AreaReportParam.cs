using System;
using System.Collections.Generic;
using System.Text;

namespace ACFIP.Data.Dtos.Area
{
    public class AreaReportParam
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int NumberOfViolation { get; set; }
                    
    }
}
