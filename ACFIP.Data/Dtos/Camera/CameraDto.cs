using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using ACFIP.Data.Dtos.Area;
using ACFIP.Data.Dtos.CameConfiguration;
using ACFIP.Data.Dtos.CameraCamConfiguration;
using ACFIP.Data.Dtos.ViolationCase;

namespace ACFIP.Data.Dtos.Camera
{
    public class CameraDto : BaseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Status { get; set; }
        public bool DeletedFlag { get; set; }
        public AreaDto Area { get; set; }
        public virtual CameraCamConfigDto CameraCamConfiguration { get; set; }

    }
}
