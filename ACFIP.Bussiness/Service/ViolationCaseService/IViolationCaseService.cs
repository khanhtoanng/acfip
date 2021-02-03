using ACFIP.Data.Dtos;
using ACFIP.Data.Dtos.ViolationCase;
using ACFIP.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ACFIP.Bussiness.Service.ViolationCaseService
{
    public interface IViolationCaseService
    {
        public Task<ViolationCaseDto> CreateViolation(ViolationRequestParam param);
        public Task<IEnumerable<ViolationCaseDto>> GetAllViolation(PagingRequestParam param);
        public Task<ViolationCaseDto> GetDetailViolation(int id);
    }
}
