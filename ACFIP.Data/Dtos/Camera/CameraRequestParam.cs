using System;
using System.Collections.Generic;
using System.Text;

namespace ACFIP.Data.Dtos.Camera
{
    public class CameraRequestParam
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AreaId { get; set; }
        public int Status { get; set; }
        public int CameraSettingId { get; set; }
        public double Angle { get; set; }
        public double Height { get; set; }

        public string ConnectionUrl { get; set; }
        //public int Options { get; set; }
    }
}
