using ACFIP.Data.Dtos.Area;
using ACFIP.Data.Dtos.Camera;
using System;
using System.Collections.Generic;
using System.Text;

namespace ACFIP.Data.Dtos.GroupCamera
{
    public class GroupCameraDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool DeletedFlag { get; set; } = false;
        public int AreaId { get; set; }
        public List<CameraDto> Cameras { get; set; }

    }
}
