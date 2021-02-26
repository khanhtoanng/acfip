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
        public int CameraId { get; set; }
        public string AreaName { get; set; }
        public string AreaDescription { get; set; }

        public virtual List<int> ViolationTypes { get; set; }
    }
}
