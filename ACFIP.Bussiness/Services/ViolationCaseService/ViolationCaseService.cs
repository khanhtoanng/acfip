﻿using ACFIP.Data.Dtos;
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
                GroupId = param.GroupId,
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

        public async Task<ViolationCaseDto> DeleteViolation(int id)
        {
            IEnumerable<ViolationCaseType> violationCaseTypes = await _uow.ViolationCaseTypeRepository.Get(filter: el => el.CaseId == id);
            foreach (ViolationCaseType type in violationCaseTypes)
            {
                _uow.ViolationCaseTypeRepository.Delete(type);
            }
            ViolationCase violationCase = await _uow.ViolationCaseRepository.GetById(id);
            _uow.ViolationCaseRepository.Delete(violationCase);
            return await _uow.SaveAsync() > 0 ? _mapper.Map<ViolationCaseDto>(violationCase) : null;

        }

        public async Task<IEnumerable<ViolationCaseDto>> GetAllViolation(ViolationRequestParam param)
        {
            IEnumerable<ViolationCaseDto> result = null;
            Func<ViolationCaseType, bool> filterType = f => true;

            var parameter = Expression.Parameter(typeof(ViolationCase), "vCase");

            var memberAccessGroup = Expression.Property(parameter, "GroupId");

            var memberAccessCreateTime = Expression.Property(parameter, "CreatedTime");
            memberAccessCreateTime = Expression.Property(memberAccessCreateTime, typeof(DateTime).GetProperty("Date"));

            Expression memberAccessArea = Expression.Property(parameter,typeof(ViolationCase).GetProperty("GroupCamera"));
            memberAccessArea = Expression.Property(memberAccessArea, typeof(GroupCamera).GetProperty("AreaId"));
            // setting default value if AreaId is null
            //memberAccessArea = Expression.Coalesce(memberAccessArea,Expression.Constant(0));


            // init
            var expr = Expression.Equal(Expression.Constant(1), Expression.Constant(1));

            if (param.AreaId != 0)
            {
                expr = Expression.AndAlso(expr, Expression.Equal(memberAccessArea, Expression.Constant(param.AreaId)));

            }
            if (param.GroupId != 0)
            {
                expr = Expression.AndAlso(expr, Expression.Equal(memberAccessGroup, Expression.Constant(param.GroupId)));
            }
            if (param.CreateTime != default )
            {
                expr = Expression.AndAlso(expr, Expression.Equal(memberAccessCreateTime, Expression.Constant(param.CreateTime.Date)));
            }
            if (param.ViolationTypeId != 0)
            {
                filterType = f => f.TypeId == param.ViolationTypeId;
            }
        
            Predicate<ViolationCaseType> predicateType = new Predicate<ViolationCaseType>(filterType);
            var filter = Expression.Lambda<Func<ViolationCase, bool>>(expr, parameter);

            IEnumerable<ViolationCase> violationCases = (await _uow.ViolationCaseRepository
                .Get(filter: filter, includeProperties: "GroupCamera,GroupCamera.Area,ViolationCaseTypes,ViolationCaseTypes.Type"))
                .Where(el => el.ViolationCaseTypes.ToList().FindIndex(predicateType) >= 0);


            result = (from vCase in violationCases
                      select new ViolationCaseDto() 
                      {
                        Id = vCase.Id,
                        CreatedTime = vCase.CreatedTime,
                        ImgUrl = vCase.ImgUrl,
                        VideoUrl = vCase.VideoUrl,
                        GroupId = vCase.GroupId,
                        GroupDescription = vCase.GroupCamera.Description,
                        AreaId = vCase.GroupCamera.AreaId,
                        AreaName = vCase.GroupCamera.Area.Name,
                        AreaDescription = vCase.GroupCamera.Area.Description,
                        ViolationTypes = vCase.ViolationCaseTypes.Select(el => new ViolationTypeDto() {Id = el.Type.Id, Name = el.Type.Name }).ToList(),
                      });

            return result;

        }

        public async Task<ViolationCaseDto> GetDetailViolation(int id)
        {
            ViolationCaseDto result = null;
            ViolationCase violationCases = (await _uow.ViolationCaseRepository
                .GetFirst(includeProperties: "GroupCamera,GroupCamera.Area,ViolationCaseTypes,ViolationCaseTypes.Type"));
            if (violationCases != null)
            {
                result = new ViolationCaseDto()
                {
                    Id = violationCases.Id,
                    CreatedTime = violationCases.CreatedTime,
                    ImgUrl = violationCases.ImgUrl,
                    VideoUrl = violationCases.VideoUrl,
                    GroupId = violationCases.GroupId,
                    GroupDescription = violationCases.GroupCamera.Description,
                    AreaId = violationCases.GroupCamera.AreaId,
                    AreaName = violationCases.GroupCamera.Area.Name,
                    AreaDescription = violationCases.GroupCamera.Area.Description,
                    ViolationTypes = violationCases.ViolationCaseTypes.Select(el => new ViolationTypeDto() { Id = el.Type.Id, Name = el.Type.Name }).ToList(),
                };
            }

            return result;
        }

        public Task<ViolationCaseDto> GetLast(int cameraId)
        {
            //return _mapper.Map<ViolationCaseDto>((await _uow.ViolationCaseRepository.Get(filter: v => v.CameraId == cameraId, orderBy: v => v.OrderByDescending(t => t.CreatedTime))).FirstOrDefault());
            return null;
        }
    }
}
