using ACFIP.Data.Dtos.Policy;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ACFIP.Bussiness.Services.PolicyService
{
    public interface IPolicyService
    {
        Task<PolicyDto> GetFirstPolicy();
        Task<PolicyDto> AddPolicy(PolicyRequestParam param);
    }
}
