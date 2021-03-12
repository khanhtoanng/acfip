using ACFIP.Data.Dtos.Policy;
using ACFIP.Data.Models;
using ACFIP.Data.UnitOfWork;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ACFIP.Bussiness.Services.PolicyService
{
    public class PolicyService : IPolicyService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public PolicyService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task<PolicyDto> AddPolicy(PolicyRequestParam param)
        {
            Policy policy = await _uow.PolicyRepository.GetFirst();
            if (policy == null)
            {
                policy = new Policy() { NumberOfViolation = param.NumberOfViolation };
                _uow.PolicyRepository.Add(policy);
            }
            else 
            {
                policy.NumberOfViolation = param.NumberOfViolation;
                _uow.PolicyRepository.Update(policy);
            }
            return await _uow.SaveAsync() > 0 ?  _mapper.Map<PolicyDto>(policy) : null;
        }

        public async Task<PolicyDto> GetFirstPolicy()
        {
            return  _mapper.Map<PolicyDto>(await _uow.PolicyRepository.GetFirst());
        }
    }
}
