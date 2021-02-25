using System;
using System.Collections.Generic;
using System.Text;

namespace ACFIP.Data.Dtos.Camera
{
    public class CameraUpdateParam
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
              
        public string ManufactureId { get; set; }
        public int AreaId { get; set; }
        public int? ConfigId { get; set; }
        public float Angle { get; set; }
        public float Height { get; set; }
        public string ConnectionString { get; set; }
    }
}
