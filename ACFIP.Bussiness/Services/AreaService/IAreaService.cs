using ACFIP.Data.Dtos;
using ACFIP.Data.Dtos.Area;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ACFIP.Bussiness.Services.AreaService
{
    public interface IAreaService
    {
        public Task<IEnumerable<AreaDto>> GetAllArea();
        public Task<AreaDto> GetAreaById(int id);
    }
}
