using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using ACFIP.Data.Dtos.Area;
using ACFIP.Data.Dtos.CameConfiguration;

namespace ACFIP.Data.Dtos.Camera
{
    public class CameraDto : BaseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public bool DeletedFlag { get; set; }
        public string ConnectionString { get; set; }

        public AreaDto Area { get; set; }
        public virtual CameraConfigurationDto Config { get; set; }

    }
}
