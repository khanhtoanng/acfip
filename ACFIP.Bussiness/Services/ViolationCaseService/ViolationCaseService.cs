using ACFIP.Data.Dtos;
using ACFIP.Data.Dtos.ViolationCase;
using ACFIP.Data.Dtos.ViolationType;
using ACFIP.Data.Models;
using ACFIP.Data.UnitOfWork;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Linq.Expressions;

namespace ACFIP.Bussiness.Services.ViolationCaseService
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

        public async Task<ViolationCaseDto> CreateViolation(ViolationCreateParam param)
        {
            ViolationCase violationCase = new ViolationCase()
            {
                ImgUrl = param.ImageUrl,
                VideoUrl = param.VideoUrl,
                CameraId = param.CameraId
            };
            _uow.ViolationCaseRepository.Add(violationCase);
            if (await _uow.SaveAsync() > 0)
            {
                List<int> listType = param.ListViolationType;
                foreach (int type in listType)
                {
                    ViolationCaseType caseType = new ViolationCaseType()
                    {
                        CaseId = violationCase.Id,
                        TypeId = type
                    };
                    _uow.ViolationCaseTypeRepository.Add(caseType);
                }
                return await _uow.SaveAsync() > 0
                    ? _mapper.Map<ViolationCaseDto>(violationCase)
                    : throw new Exception("Insert to [violation_case_violation_type] fails");
            }
            else
            {
                throw new Exception("Insert to [violation_case] fails");
            }

        }

        public async Task<IEnumerable<ViolationCaseDto>> GetAllViolation(ViolationRequestParam param)
        {
            IEnumerable<ViolationCase> listViolationCase = await _uow.ViolationCaseRepository
                .Get(filter: el => el.CameraId == param.CameraId && el.Camera.AreaId == param.AreaId,
                includeProperties: "Camera,Camera.Area");

            var listViolationCaseType =( await _uow.ViolationCaseTypeRepository
                                        .Get(filter: el => el.TypeId == param.ViolationTypeId))
                                        .GroupBy(el => el.CaseId);


            List<ViolationCaseDto> list = ((List<ViolationCaseDto>)(from vCase in listViolationCase
                                                                    join vType in listViolationCaseType
                                                                    on vCase.Id equals vType.Key
                                                                    select new ViolationCaseDto()
                                                                    {
                                                                        Id = vCase.Id,
                                                                        CreatedTime = vCase.CreatedTime,
                                                                        LastModifiedTime = vCase.LastModifiedTime,
                                                                        ImgUrl = vCase.ImgUrl,
                                                                        VideoUrl = vCase.VideoUrl,
                                                                        ListViolationType = _mapper.Map<List<ViolationTypeDto>>(vType.GetEnumerator())
                                                                    })).ToList();
            
            return list;
        }

        public async Task<ViolationCaseDto> GetDetailViolation(int id)
        {
            ViolationCase violationCase = await _uow.ViolationCaseRepository
                .GetFirst(filter: el => el.Id == id,
                includeProperties: "Camera,ViolationCaseTypes.Type");
            return _mapper.Map<ViolationCaseDto>(violationCase);
        }
    }
}
