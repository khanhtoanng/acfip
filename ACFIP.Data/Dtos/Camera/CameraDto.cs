using System;
using System.Collections.Generic;
using System.Text;
using ACFIP.Data.Dtos.Area;
using ACFIP.Data.Dtos.CameConfiguration;
using ACFIP.Data.Dtos.CameraSetting;
using ACFIP.Data.Dtos.ViolationCase;

namespace ACFIP.Data.Dtos.Camera
{
    public class CameraDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Status { get; set; }
        public int DelFlg { get; set; }
        public virtual AreaDto Area { get; set; }
        public virtual ICollection<CameraConfigurationDto> CameraConfigurations { get; set; }
        public virtual ICollection<ViolationCaseDto> ViolationCases { get; set; }
    }
}
