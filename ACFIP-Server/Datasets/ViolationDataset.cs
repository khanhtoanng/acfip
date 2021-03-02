using System.Collections.Generic;

namespace ACFIP_Server.Datasets
{
    public class ViolationDataset
    {
        public int Id { get; set; }
        public int GroupCamId { get; set; }
        public string ImgUrl { get; set; }
        public string VideoUrl { get; set; }
        public List<string> Types { get; set; }
    }
}
