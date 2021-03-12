using ACFIP.Data.Dtos.Area;
using System;
using System.Collections.Generic;
using System.Text;

namespace ACFIP.Data.Dtos.Guard
{
    public class GuardDto
    {
        public int Id { get; set; }
        public AreaDto Area { get; set; }
        public string FullName { get; set; }
        public TimeSpan TimeStart { get; set; }
        public TimeSpan TimeEnd { get; set; }
    }
}
