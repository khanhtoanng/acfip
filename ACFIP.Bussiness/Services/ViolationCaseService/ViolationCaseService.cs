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
using ACFIP.Data.Helpers;

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

        public async Task<int> CountAlViolaition()
        {
            return (await _uow.ViolationCaseRepository.Get()).Count();
        }

        public async Task<int> CountNonDetectedViolation()
        {
            return (await _uow.ViolationCaseRepository.Get(filter: el => el.Status == AppConstants.ViolationStatus.NON_DETECTED)).Count();

        }

        public async Task<ViolationCaseDto> CreateViolation(ViolationCreateParam param)
        {
            ViolationCase violationCase = new ViolationCase()
            {
                ImgUrl = param.ImageUrl,
                VideoUrl = param.VideoUrl,
                LocationId = param.LocationId,
                CreatedTime = param.CreateTime
            };
            Data.Models.Location location = await _uow.LocationRepository.GetFirst(filter: el => el.Id == param.LocationId);
            int a = 0;
            Guard guard = await _uow.GuardRepository.GetFirst(
                filter: el => (el.TimeStart <= DateTime.Now.TimeOfDay && el.TimeEnd >= DateTime.Now.TimeOfDay) && el.AreaId == location.AreaId);

            if (guard != null) { violationCase.GuardName = guard.FullName; }
            

            _uow.ViolationCaseRepository.Add(violationCase);
            if (await _uow.SaveAsync() > 0)
            {
                foreach (string type in param.ViolationTypes)
                {
                    int typeId = (await _uow.ViolationTypeRepository.GetFirst(filter: el => el.Name.ToLower() == type.ToLower())).Id;
                    _uow.ViolationCaseTypeRepository.Add(new ViolationCaseType() { CaseId = violationCase.Id, TypeId = typeId });
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

            var memberAccessGroup = Expression.Property(parameter, "LocationId");

            var memberAccesStatus = Expression.Property(parameter, "Status");

            var memberAccessCreateTime = Expression.Property(parameter, "CreatedTime");
            memberAccessCreateTime = Expression.Property(memberAccessCreateTime, typeof(DateTime).GetProperty("Date"));

            var memberAccessMonth = Expression.Property(parameter, "CreatedTime");
            memberAccessMonth = Expression.Property(memberAccessMonth, typeof(DateTime).GetProperty("Month"));

            Expression memberAccessArea = Expression.Property(parameter, typeof(ViolationCase).GetProperty("Location"));
            memberAccessArea = Expression.Property(memberAccessArea, typeof(Data.Models.Location).GetProperty("AreaId"));
            // setting default value if AreaId is null
            memberAccessArea = Expression.Coalesce(memberAccessArea, Expression.Constant(0));


            // init
            var expr = Expression.Equal(Expression.Constant(1), Expression.Constant(1));

            if (param.AreaId != 0)
            {
                expr = Expression.AndAlso(expr, Expression.Equal(memberAccessArea, Expression.Constant(param.AreaId)));

            }
            if (param.LocationId != 0)
            {
                expr = Expression.AndAlso(expr, Expression.Equal(memberAccessGroup, Expression.Constant(param.LocationId)));
            }
            if (param.CreateTime != default)
            {
                expr = Expression.AndAlso(expr, Expression.Equal(memberAccessCreateTime, Expression.Constant(param.CreateTime.Date)));
            }
            if (param.Status != null)
            {
                expr = Expression.AndAlso(expr, Expression.Equal(memberAccesStatus, Expression.Constant(param.Status)));
            }
            if (param.Month != 0) 
            {
                expr = Expression.AndAlso(expr, Expression.Equal(memberAccessMonth, Expression.Constant(param.Month)));
            }
            if (param.ViolationTypeId != 0)
            {
                filterType = f => f.TypeId == param.ViolationTypeId;
            }

            Predicate<ViolationCaseType> predicateType = new Predicate<ViolationCaseType>(filterType);
            var filter = Expression.Lambda<Func<ViolationCase, bool>>(expr, parameter);

            IEnumerable<ViolationCase> violationCases = (await _uow.ViolationCaseRepository
                .Get(filter: filter, includeProperties: "Location,Location.Area,ViolationCaseTypes,ViolationCaseTypes.Type"))
                .Where(el => el.ViolationCaseTypes.ToList().FindIndex(predicateType) >= 0);


            result = (from vCase in violationCases
                      select new ViolationCaseDto()
                      {
                          Id = vCase.Id,
                          CreatedTime = vCase.CreatedTime,
                          ImgUrl = vCase.ImgUrl,
                          VideoUrl = vCase.VideoUrl,
                          LocationId = vCase.LocationId,
                          LocationDescription = vCase.Location.Description,
                          AreaId = vCase.Location.AreaId,
                          AreaName = vCase.Location.Area.Name,
                          AreaDescription = vCase.Location.Area.Description,
                          GuardName = vCase.GuardName,
                          Status = vCase.Status,
                          ViolationTypes = vCase.ViolationCaseTypes.Select(el => new ViolationTypeDto() { Id = el.Type.Id, Name = el.Type.Name }).ToList(),
                      });

            return result;

        }

        public async Task<ViolationCaseDto> GetDetailViolation(int id)
        {
            ViolationCaseDto result = null;
            ViolationCase violationCases = (await _uow.ViolationCaseRepository
                .GetFirst(filter: el => el.Id == id, includeProperties: "Location,Location.Area,ViolationCaseTypes,ViolationCaseTypes.Type"));
            if (violationCases != null)
            {
                result = new ViolationCaseDto()
                {
                    Id = violationCases.Id,
                    CreatedTime = violationCases.CreatedTime,
                    ImgUrl = violationCases.ImgUrl,
                    VideoUrl = violationCases.VideoUrl,
                    LocationId = violationCases.LocationId,
                    LocationDescription = violationCases.Location.Description,
                    AreaId = violationCases.Location.AreaId,
                    AreaName = violationCases.Location.Area.Name,
                    AreaDescription = violationCases.Location.Area.Description,
                    GuardName = violationCases.GuardName,
                    Status = violationCases.Status,
                    ViolationTypes = violationCases.ViolationCaseTypes.Select(el => new ViolationTypeDto() { Id = el.Type.Id, Name = el.Type.Name }).ToList(),
                };
            }

            return result;
        }

        public async Task<ViolationCaseDto> GetLast(int groupId)
        {
            return _mapper.Map<ViolationCaseDto>((await _uow.ViolationCaseRepository.Get(filter: el => el.LocationId == groupId, orderBy: el => el.OrderByDescending(t => t.CreatedTime))).FirstOrDefault());
        }

        public async Task<IEnumerable<ViolationReport>> GetViolationReport()
        {
            IEnumerable<ViolationCase> violationCases = await _uow.ViolationCaseRepository.Get();
            IEnumerable<ViolationReport> result = violationCases.GroupBy(el => el.CreatedTime.Month).Select(el => new ViolationReport { Month = el.Key, NumberOfViolations = el.Count()}).OrderBy(el => el.Month);
            return result;
        }

        public async Task<ViolationReport> GetViolationReportInMonth(int month)
        {
            IEnumerable<ViolationCase> violationCases = await _uow.ViolationCaseRepository.Get(filter: el => el.CreatedTime.Month == month,includeProperties: "ViolationCaseTypes,ViolationCaseTypes.Type");
            ViolationReport violationReport = new ViolationReport() { Month = month, NumberOfViolations = violationCases.Count() };
            var listVest = violationCases.Where(el => el.ViolationCaseTypes.ToList().FindIndex(f => f.TypeId == AppConstants.ViolationType.VEST) >= 0);
            TypeReport vestReport = new TypeReport() {Type = "Vest", NumberOfViolation = listVest.Count() };
            var listHelmet = violationCases.Where(el => el.ViolationCaseTypes.ToList().FindIndex(f => f.TypeId == AppConstants.ViolationType.HELMET) >= 0);
            TypeReport helmettReport = new TypeReport() { Type = "Helmet", NumberOfViolation = listHelmet.Count() };
            violationReport.TypeReports.Add(vestReport);
            violationReport.TypeReports.Add(helmettReport);
            return violationReport;
        }

        public async Task<ViolationCaseDto> UpdateStatus(int id, ViolationCaseUpdateStatusParam param)
        {
            ViolationCase violationCase = await _uow.ViolationCaseRepository.GetById(id);
            if (violationCase != null)
            {
                violationCase.Status = param.Status;
                _uow.ViolationCaseRepository.Update(violationCase);
            }
            return await _uow.SaveAsync() > 0 ? _mapper.Map<ViolationCaseDto>(violationCase) : null;
        }
    }
}
