﻿using ACFIP.Data.Dtos;
using ACFIP.Data.Dtos.Area;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ACFIP.Bussiness.Service.AreaService
{
    public interface IAreaService
    {
        public Task<IEnumerable<AreaDto>> GetAllArea(PagingRequestParam param);
    }
}