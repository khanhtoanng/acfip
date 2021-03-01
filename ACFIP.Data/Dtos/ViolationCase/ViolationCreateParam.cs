using ACFIP.Data.Dtos.ViolationType;
using System;
using System.Collections.Generic;
using System.Text;

namespace ACFIP.Data.Dtos.ViolationCase
{
    public class ViolationCreateParam
    {
        public string ImageUrl { get; set; }
        public string VideoUrl { get; set; }
        public int GroupId { get; set; }

        public virtual List<int> ViolationTypes { get; set; }
    }
}
