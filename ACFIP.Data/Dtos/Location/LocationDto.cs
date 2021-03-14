using ACFIP.Data.Dtos.Area;
using ACFIP.Data.Dtos.Camera;
using System;
using System.Collections.Generic;
using System.Text;

namespace ACFIP.Data.Dtos.Location
{
    public class LocationDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool DeletedFlag { get; set; } = false;
        public int NumberOfCameras { get; set; }
        public int? AreaId { get; set; }

    }
}
