using System;
using System.Collections.Generic;
using System.Text;

namespace ACFIP.Data.Dtos.GroupCamera
{
    public class GroupCameraCreateParam
    {
        public string Description { get; set; }
        public bool DeletedFlag { get; set; } = false;
        public int AreaId { get; set; }
    }
}
