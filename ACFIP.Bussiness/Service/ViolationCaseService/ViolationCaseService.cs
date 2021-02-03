using ACFIP.Data.Dtos;
using ACFIP.Data.Dtos.ViolationCase;
using ACFIP.Data.Dtos.ViolationType;
using ACFIP.Data.Models;
using ACFIP.Data.UnitOfWork;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ACFIP.Bussiness.Service.ViolationCaseService
{
    public class ViolationCaseService : IViolationCaseService
    {
        private IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public ViolationCaseService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<ViolationCaseDto> CreateViolation(ViolationRequestParam param)
        {
            ViolationCase violationCase = new ViolationCase()
            {
                CreateTime = DateTime.Now,
                ImageUrl = param.ImageUrl,
                VideoUrl = param.VideoUrl,
                CameraId = param.CameraId
            };
            _uow.ViolationCaseRepository.Add(violationCase);
            if (await _uow.SaveAsync() > 0)
            {
                List<ViolationType> listType = _mapper.Map<List<ViolationType>>(param.ListViolationType);
                foreach (ViolationType type in listType)
                {
                    ViolationCaseType caseType = new ViolationCaseType()
                    {
                        ViolationCaseId = violationCase.Id,
                        ViolationTypeId = type.Id
                    };
                    _uow.ViolationCaseTypeRepository.Add(caseType);
                }
                return (await _uow.SaveAsync() > 0)
                    ? _mapper.Map<ViolationCaseDto>(violationCase)
                    : throw new Exception("Insert to [violation_case_type] fails");
            }
            else
            {
                throw new Exception("Insert to [violation_case] fails");
            }

        }

        public async Task<IEnumerable<ViolationCaseDto>> GetAllViolation(PagingRequestParam param)
        {
            IEnumerable<ViolationCase> listViolationCase = await _uow.ViolationCaseRepository
                         .Get(pageIndex: param.PageIndex, pageSize: param.PageSize,
                         includeProperties: "Camera,ViolationCaseTypes.ViolationType");
            return _mapper.Map<IEnumerable<ViolationCaseDto>>(listViolationCase);
        }

        public async Task<ViolationCaseDto> GetDetailViolation(int id)
        {
            ViolationCase violationCase = await _uow.ViolationCaseRepository
                .GetFirst(filter: el => el.Id == id,
                includeProperties: "Camera,ViolationCaseTypes.ViolationType");
            return _mapper.Map<ViolationCaseDto>(violationCase);
        }
    }
}
