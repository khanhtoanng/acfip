using System;
using System.Collections.Generic;
using System.Text;
using ACFIP.Data.Dtos.Camera;

namespace ACFIP.Data.Dtos.Area
{
    public class AreaDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<CameraDto> Cameras { get; set; }
    }
}
