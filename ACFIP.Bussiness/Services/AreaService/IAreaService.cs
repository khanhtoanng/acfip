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
        public Task<IEnumerable<AreaDto>> GetAllAreaForFilter();        
        public Task<AreaDto> CreateArea(AreaCreateParam param);
        public Task<AreaDto> DeleteArea(int id);
        public Task<AreaDto> UpdateArea(AreaUpdateParam param);
        public Task<IEnumerable<AreaDto>> GetReportArea(ReportParam param);
        public Task<int> CountAllArea();
        public Task<IEnumerable<AreaDto>> GetAreaViolatedPolicyInMonth(ReportParam param);
        public Task<IEnumerable<AreaDto>> GetTopThreeAreaViolatedInMonth(ReportParam param);
    }
}
