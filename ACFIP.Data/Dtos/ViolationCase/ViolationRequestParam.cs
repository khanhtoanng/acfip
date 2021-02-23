using System;
using System.Collections.Generic;
using System.Text;

namespace ACFIP.Data.Dtos.ViolationCase
{
    public class ViolationRequestParam : PagingRequestParam
    {
        public int CameraId { get; set; }
        public int AreaId { get; set; }
        public int ViolationTypeId {get;set;}
        public DateTime CreateTime { get; set; }
    }
}
