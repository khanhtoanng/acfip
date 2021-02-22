using System;
using System.Collections.Generic;
using System.Text;

namespace ACFIP.Data.Dtos.Camera
{
    public class CameraRequestParam : PagingRequestParam
    {
        public int? AreaId { get; set; }
    }
}
