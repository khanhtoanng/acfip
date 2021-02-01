using ACFIP.Data.Dtos.CameConfiguration;
using System;
using System.Collections.Generic;
using System.Text;

namespace ACFIP.Data.Dtos.CameraSetting
{
    public class CameraSettingDto
    {
        public int Id { get; set; }
        public double? Height { get; set; }
        public double? Angle { get; set; }
        public virtual ICollection<CameraConfigurationDto> CameraConfigurations { get; set; }
    }
}
