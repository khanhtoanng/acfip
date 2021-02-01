using ACFIP.Data.Dtos.Camera;
using ACFIP.Data.Dtos.CameraSetting;
using System;
using System.Collections.Generic;
using System.Text;

namespace ACFIP.Data.Dtos.CameConfiguration
{
    public class CameraConfigurationDto
    {
        public int CameraId { get; set; }
        public int CameraSettingId { get; set; }
        public string ConnectionUrl { get; set; }
        public virtual CameraDto Camera { get; set; }
        public virtual CameraSettingDto CameraSetting { get; set; }
    }
}
