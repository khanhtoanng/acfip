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
using ACFIP.Data.Dtos.ViolationCaseType;
using ACFIP.Data.Dtos.Camera;

namespace ACFIP.Bussiness.Services.ViolationCaseService
{
    public class ViolationCaseService : IViolationCaseService
    {
        private readonly IMapper _mapper;
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
                List<int> listType = param.ViolationTypes;
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
            IEnumerable<ViolationCaseDto> result = null;
            Func<ViolationCaseType, bool> filterType = f => true;

            var parameter = Expression.Parameter(typeof(ViolationCase), "vCase");

            var memberAccessCamera = Expression.Property(parameter, "CameraId");

            var memberAccessCreateTime = Expression.Property(parameter, "CreatedTime");

            Expression memberAccessArea = Expression.Property(parameter,typeof(ViolationCase).GetProperty("Camera"));
            memberAccessArea = Expression.Property(memberAccessArea, typeof(Camera).GetProperty("AreaId"));
            // setting default value if AreaId is null
            memberAccessArea = Expression.Coalesce(memberAccessArea,Expression.Constant(param.AreaId));


            // init
            var expr = Expression.Equal(Expression.Constant(1), Expression.Constant(1));

            if (param.AreaId != 0)
            {
                expr = Expression.AndAlso(expr, Expression.Equal(memberAccessArea, Expression.Constant(param.AreaId)));

            }
            if (param.CameraId != 0)
            {
                expr = Expression.AndAlso(expr, Expression.Equal(memberAccessCamera, Expression.Constant(param.CameraId)));
            }
            if (param.CreateTime != null)
            {
                expr = Expression.AndAlso(expr, Expression.GreaterThanOrEqual(memberAccessCreateTime, Expression.Constant(param.CreateTime)));
            }
            if (param.ViolationTypeId != 0)
            {
                filterType = f => f.TypeId == param.ViolationTypeId;
            }
        
            Predicate<ViolationCaseType> predicateType = new Predicate<ViolationCaseType>(filterType);
            var filter = Expression.Lambda<Func<ViolationCase, bool>>(expr, parameter);

            IEnumerable<ViolationCase> violationCases = (await _uow.ViolationCaseRepository
                .Get(filter: filter, includeProperties: "Camera,Camera.Area,ViolationCaseTypes,ViolationCaseTypes.Type"))
                .Where(el => el.ViolationCaseTypes.ToList().FindIndex(predicateType) >= 0);


            result = (from vCase in violationCases
                      select new ViolationCaseDto() 
                      {
                        Id = vCase.Id,
                        CreatedTime = vCase.CreatedTime,
                        ImgUrl = vCase.ImgUrl,
                        VideoUrl = vCase.VideoUrl,
                        CameraId = vCase.CameraId,
                        CameraName = vCase.Camera.Name,
                        AreaId    = vCase.Camera.AreaId,
                        AreaName = vCase.Camera.Area.Name,
                        CameraManufactureId = vCase.Camera.ManufactureId,
                        ViolationTypes = vCase.ViolationCaseTypes.Select(el => new ViolationTypeDto() {Id = el.Type.Id, Name = el.Type.Name }).ToList(),
                      });

            return result;

        }

        public async Task<ViolationCaseDto> GetDetailViolation(int id)
        {
            return _mapper.Map<ViolationCaseDto>(await _uow.ViolationCaseRepository.GetById(id));

        }

        public async Task<ViolationCaseDto> GetLast(int cameraId)
        {
            return _mapper.Map<ViolationCaseDto>((await _uow.ViolationCaseRepository.Get(filter: v => v.CameraId == cameraId, orderBy: v => v.OrderByDescending(t => t.CreatedTime))).FirstOrDefault());
        }
    }
}
