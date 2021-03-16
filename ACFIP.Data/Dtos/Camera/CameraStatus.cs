using ACFIP.Data.Dtos.CameConfiguration;
using ACFIP.Data.Dtos.Location;
using System;
using System.Collections.Generic;
using System.Text;

namespace ACFIP.Data.Dtos.Camera
{
    public class CameraStatus
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? LocationId { get; set; }
        public int? ConfigId { get; set; }
        public string ConnectionString { get; set; }
        public bool IsActive { get; set; } = false;
        public bool DeletedFlag { get; set; } = false;
    }
}
