using ACFIP.Data.Dtos.Camera;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ACFIP.Data.Dtos.CameConfiguration
{
    public class CameraConfigurationDto : BaseDto
    {
        public int Id { get; set; }
        public float Height { get; set; }
        public float Angle { get; set; }
    }
}
