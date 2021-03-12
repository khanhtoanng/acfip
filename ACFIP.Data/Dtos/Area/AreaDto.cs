using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using ACFIP.Data.Dtos.Camera;
using ACFIP.Data.Dtos.Location;

namespace ACFIP.Data.Dtos.Area
{
    public class AreaDto  : BaseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool DeletedFlag { get; set; }
        public List<CameraDto> Cameras { get; set; }

    }
}
