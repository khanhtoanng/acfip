using System;
using System.Collections.Generic;
using System.Text;

namespace ACFIP.Data.Dtos
{
    public class PagingRequestParam
    {
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
    }
}
