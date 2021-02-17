using System;
using System.Collections.Generic;
using System.Text;

namespace ACFIP.Data.Dtos.Camera
{
    public class CameraUpdateParam
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Status { get; set; }
        public int AreaId { get; set; }
        public int CameraConfigId { get; set; }
        public float Angle { get; set; }
        public float Height { get; set; }
        public string ConnectionString { get; set; }
    }
}
