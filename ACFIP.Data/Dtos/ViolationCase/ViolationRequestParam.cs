using ACFIP.Data.Dtos.ViolationType;
using System;
using System.Collections.Generic;
using System.Text;

namespace ACFIP.Data.Dtos.ViolationCase
{
    public class ViolationRequestParam
    {
        public string ImageUrl { get; set; }
        public string VideoUrl { get; set; }
        public int? CameraId { get; set; }

        public virtual ICollection<ViolationTypeDto> ListViolationType { get; set; }
    }
}
