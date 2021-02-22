using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ACFIP_Server.Datasets.ViolationCase
{
    public class ViolationDataset
    {
        public int Id { get; set; }
        public int CameraId { get; set; }
        public string ImgUrl { get; set; }
        public string VideoUrl { get; set; }
    }
}
