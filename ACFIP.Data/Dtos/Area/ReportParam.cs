using System;
using System.Collections.Generic;
using System.Text;

namespace ACFIP.Data.Dtos.Area
{
    public class ReportParam
    {
        public int Month { get; set; }
        public int Year { get; set; }
        public int Day { get; set; }
        public int Quarter { get; set; }
        public int AreaId { get; set; }
    }
}
