using System;
using System.Collections.Generic;
using System.Text;

namespace ACFIP.Data.Dtos.Guard
{
   public class GuardParam
    {
        public string FullName { get; set; }
        public TimeSpan TimeStart { get; set; }
        public TimeSpan TimeEnd { get; set; }
    }
}
