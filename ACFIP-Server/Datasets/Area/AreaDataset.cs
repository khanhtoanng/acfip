using ACFIP_Server.Datasets.Camera;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ACFIP_Server.Datasets.Area
{
    public class AreaDataset
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public List<CameraDataset> Cameras { get; set; }
    }

    public class AreaCreateDataset
    {
        public string Description { get; set; }
    }
}
