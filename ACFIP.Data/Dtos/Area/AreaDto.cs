using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using ACFIP.Data.Dtos.Camera;
using ACFIP.Data.Dtos.Guard;
using ACFIP.Data.Dtos.Location;
using ACFIP.Data.Helpers;

namespace ACFIP.Data.Dtos.Area
{
    public class AreaDto : BaseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool DeletedFlag { get; set; }
        public int NumberOfLocations { get; set; }
        public int NumberOfCameras { get; set; } 
        public int NumberOfViolations { get; set; }
        public int ViolatedStatus { get; set; } = AppConstants.AreaViolated.LOWER_POLICY;
        public double Frequency { get; set; }
        public DateTime? DateOfViolation { get; set; }
        public List<CameraDto> Cameras { get; set; }
        public List<GuardParam> Guards { get; set; }

    }
}
