using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ACFIP_Server.Datasets.Camera
{
    public class CameraDataset
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public string ConnectionString { get; set; }
        public int? AreaId { get; set; }
        public int? ConfigId { get; set; }
        public float Height { get; set; }
        public float Angle { get; set; }
    }

}
