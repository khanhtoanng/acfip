using ACFIP.Data.Dtos;
using ACFIP.Data.Dtos.ViolationCase;
using ACFIP.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ACFIP.Bussiness.Services.ViolationCaseService
{
    public interface IViolationCaseService
    {
        public Task<ViolationCaseDto> CreateViolation(ViolationCreateParam param);
        public Task<IEnumerable<ViolationCaseDto>> GetAllViolation(ViolationRequestParam param);
        public Task<ViolationCaseDto> GetDetailViolation(int id);
        public Task<ViolationCaseDto> GetLast(int locationId);
        public Task<ViolationCaseDto> DeleteViolation(int id);
        public Task<ViolationCaseDto> UpdateStatus(int id,ViolationCaseUpdateStatusParam param);
        public Task<IEnumerable<ViolationReport>> GetViolationReport();
        public Task<ViolationReport> GetViolationReportInMonth(int month);

    }
}
