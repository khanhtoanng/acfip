using System.Collections.Generic;

namespace ACFIP_Server.Datasets
{
    public class AreaDataset
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<CameraDataset> Cameras { get; set; }
    }

    public class AreaCreateDataset
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
