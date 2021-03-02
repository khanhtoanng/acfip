using System.Collections.Generic;

namespace ACFIP_Server.Datasets
{
    public class CameraDataset
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public string ConnectionString { get; set; }
        public int? GroupId { get; set; }
        public int? AreaId { get; set; }
        public int? ConfigId { get; set; }
        public float Height { get; set; }
        public float Angle { get; set; }
    }

    public class GroupCamDataset
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int AreaId { get; set; }
        public List<CameraDataset> Cameras { get; set; }
    }

    public class GroupCreateDataset
    {
        public string Description { get; set; }
        public int AreaId { get; set; }
    }

    public class CameraUpdateDataset
    {
        public int CamId { get; set; }
        public bool Status { get; set; }
    }
}
