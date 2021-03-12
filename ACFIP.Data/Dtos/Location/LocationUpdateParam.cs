using System;
using System.Collections.Generic;
using System.Text;

namespace ACFIP.Data.Dtos.Location
{
    public class LocationUpdateParam
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int? AreaId { get; set; }
    }
}
