using System;
using System.Collections.Generic;
using System.Text;

namespace ACFIP.Data.Dtos.GroupCamera
{
    public class GroupCameraUpdateParam
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int? AreaId { get; set; }
    }
}
