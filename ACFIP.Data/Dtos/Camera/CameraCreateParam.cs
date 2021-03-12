using System;
using System.Collections.Generic;
using System.Text;

namespace ACFIP.Data.Dtos.Camera
{
    public class CameraCreateParam
    {
        public string Name { get; set; }
        public int LocationId { get; set; }
        public int? ConfigId { get; set; }
        public float Angle { get; set; }
        public float Height { get; set; }
        public string ConnectionString { get; set; }
    }
}
