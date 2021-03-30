using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using ACFIP.Data.Dtos.Camera;
using ACFIP.Data.Dtos.Location;
using ACFIP.Data.Dtos.ViolationCaseType;
using ACFIP.Data.Dtos.ViolationType;

namespace ACFIP.Data.Dtos.ViolationCase
{
    public class ViolationCaseDto
    {
        public int Id { get; set; }
        public string ImgUrl { get; set; }
        public string VideoUrl { get; set; }
        public int Status { get; set; }
        public string GuardName { get; set; }
        public int? CameraId { get; set; }
        public string CameraName { get; set; }
        public int? LocationId { get; set; }
        public string LocationDescription { get; set; }
        public int? AreaId { get; set; }
        public string AreaName { get; set; }
        public string AreaDescription { get; set; }
        public bool IsView { get; set; }

        public virtual List<ViolationTypeDto> ViolationTypes { get; set; }
        public DateTime CreatedTime { get; set; }

    }
}
