using ACFIP.Data.Dtos.Area;
using ACFIP.Data.Dtos.Policy;
using ACFIP.Data.Models;
using ACFIP.Data.UnitOfWork;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
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
            return await _uow.SaveAsync() > 0 ?  _mapper.Map<PolicyDto>(policy) : throw new Exception("Can not add policy");
        }

        public async Task<PolicyDto> GetFirstPolicy()
        {
            return  _mapper.Map<PolicyDto>(await _uow.PolicyRepository.GetFirst());
        }

        public async Task<AreaDto> IsInValidArea(int cameraId)
        {
            int currentMonth = DateTime.Now.Month;
            Area area = (await _uow.CameraRepository.GetFirst(filter: el => el.Id == cameraId,includeProperties: "Location,Location.Area")).Location.Area;
            if (area.DateOfViolation == null || area.DateOfViolation.Value.Month != currentMonth) 
            {
                Policy policy = await _uow.PolicyRepository.GetFirst();
                var numberOfViolationsInMonth = (await _uow.ViolationCaseRepository
                    .Get(filter: el => el.Camera.Location.AreaId == area.Id && el.CreatedTime.Month == currentMonth)).Count();

                if (numberOfViolationsInMonth > policy.NumberOfViolation)
                {
                    area.DateOfViolation = DateTime.UtcNow;
                    _uow.AreaRepository.Update(area);
                }
            }
            return await _uow.SaveAsync() > 0 ? _mapper.Map<AreaDto>(area) : null;
        }
    }
}
