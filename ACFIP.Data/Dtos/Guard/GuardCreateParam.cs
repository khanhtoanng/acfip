using System;
using System.Collections.Generic;
using System.Text;

namespace ACFIP.Data.Dtos.Guard
{
   public class GuardCreateParam
    {
        public string AreaName { get; set; }
        public string FullName { get; set; }
        public TimeSpan? TimeStart { get; set; }
        public TimeSpan? TimeEnd { get; set; }

    }
}
