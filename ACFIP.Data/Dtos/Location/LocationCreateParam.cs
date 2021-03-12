using System;
using System.Collections.Generic;
using System.Text;

namespace ACFIP.Data.Dtos.Location
{
    public class LocationCreateParam
    {
        public string Description { get; set; }
        public bool DeletedFlag { get; set; } = false;
        public int AreaId { get; set; }
    }
}
