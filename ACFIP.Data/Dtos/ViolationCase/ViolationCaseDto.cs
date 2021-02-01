using System;
using System.Collections.Generic;
using System.Text;
using ACFIP.Data.Dtos.Camera;
using ACFIP.Data.Dtos.ViolationCaseType;
using ACFIP.Data.Dtos.ViolationType;

namespace ACFIP.Data.Dtos.ViolationCase
{
    public class ViolationCaseDto
    {
        public int Id { get; set; }
        public DateTime? CreateTime { get; set; }
        public string ImageUrl { get; set; }
        public string VideoUrl { get; set; }
        public int? CameraId { get; set; }

        public virtual CameraDto Camera { get; set; }
        public virtual ICollection<ViolationCaseTypeDto> ViolationCaseTypes { get; set; }
    }
}
