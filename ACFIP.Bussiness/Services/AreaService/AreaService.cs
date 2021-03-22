using ACFIP.Data.Dtos;
using ACFIP.Data.Dtos.Area;
using ACFIP.Data.Models;
using ACFIP.Data.UnitOfWork;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using ACFIP.Data.Dtos.Camera;
using ACFIP.Data.Helpers;
using ACFIP.Data.Dtos.Guard;

namespace ACFIP.Bussiness.Services.AreaService
{
    public class AreaService : IAreaService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public AreaService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<AreaDto> CreateArea(AreaCreateParam param)
        {
            Area area = new Area()
            {
                Name = param.Name,
                Description = param.Description
            };
            _uow.AreaRepository.Add(area);
            if (await _uow.SaveAsync() > 0)
            {
                _uow.LocationRepository.Add(new Data.Models.Location() { AreaId = area.Id, Description = "Default location" });
                await _uow.SaveAsync();
                return _mapper.Map<AreaDto>(area);
            }
            return null;
        }

        public async Task<IEnumerable<AreaDto>> GetAllAreaForFilter()
        {
            return _mapper.Map<IEnumerable<AreaDto>>(await _uow.AreaRepository.Get(filter: el => !el.DeletedFlag));
        }

        public async Task<IEnumerable<AreaDto>> GetAllArea()
        {
            IEnumerable<AreaDto> result = _mapper.Map<IEnumerable<AreaDto>>(await _uow.AreaRepository.Get(filter: el => !el.DeletedFlag));
            foreach (var area in result)
            {
                List<CameraDto> listCam = _mapper.Map<List<CameraDto>>
                    (await _uow.CameraRepository.Get(filter: el => !el.DeletedFlag && el.Location.AreaId == area.Id, includeProperties: "Location,Config"));
                IEnumerable<Data.Models.Location> listLocation = await _uow.LocationRepository.Get(filter: el => el.AreaId == area.Id);
                area.Cameras = listCam;
                area.NumberOfCameras = listCam.Count();
                area.NumberOfLocations = listLocation.Count();
            }
            return result;
        }

        public async Task<AreaDto> DeleteArea(int id)
        {
            Area area = await _uow.AreaRepository.GetById(id);
            area.DeletedFlag = true;
            _uow.AreaRepository.Update(area);
            return await _uow.SaveAsync() > 0 ? _mapper.Map<AreaDto>(area) : null;
        }

        public async Task<AreaDto> UpdateArea(AreaUpdateParam param)
        {
            Area area = await _uow.AreaRepository.GetById(param.Id);
            if (area != null)
            {
                area.Name = param.Name;
                area.Description = param.Description;

            }
            return await _uow.SaveAsync() > 0 ? _mapper.Map<AreaDto>(area) : null;
        }

        public async Task<IEnumerable<AreaDto>> GetReportArea(ReportParam param)
        {
            IEnumerable<AreaDto> result = _mapper.Map<IEnumerable<AreaDto>>(await _uow.AreaRepository.Get(filter: el => !el.DeletedFlag));
            if (param.AreaId != 0)
            {
                result = result.Where(el => el.Id == param.AreaId);
            }
            foreach (var area in result)
            {
                IEnumerable<ViolationCase> list = await _uow.ViolationCaseRepository
                    .Get(filter: el => el.Status == AppConstants.ViolationStatus.DETECTED && el.Location.AreaId == area.Id
                    , includeProperties: "Location");
                if (list != null || list.Count() != 0)
                {
                    if (param.Month != 0)
                    {
                        list = list.Where(el => el.CreatedTime.Month == param.Month);
                    }
                    area.NumberOfViolations = list.Count();
                }

            }
            Policy policy = await _uow.PolicyRepository.GetFirst();
            result = result.OrderByDescending(el => el.NumberOfViolations);
            foreach (var item in result)
            {
                item.Guards = _mapper.Map<IEnumerable<GuardParam>>(await _uow.GuardRepository.Get(filter: el => el.AreaId == item.Id)).ToList();
                if (item.NumberOfViolations > policy.NumberOfViolation) item.ViolatedStatus = AppConstants.AreaViolated.EXCEED_POLICY;
                else if (item.NumberOfViolations == policy.NumberOfViolation) item.ViolatedStatus = AppConstants.AreaViolated.EQUAL_TO_POLICY;
            }
            return result;
        }

        public async Task<int> CountAllArea()
        {
            return (await _uow.AreaRepository.Get(filter: el => !el.DeletedFlag)).Count();
        }

        public async Task<IEnumerable<AreaDto>> GetAreaViolatedPolicyInMonth(ReportParam param)
        {
            IEnumerable<AreaDto> result = _mapper.Map<IEnumerable<AreaDto>>(await _uow.AreaRepository.Get(filter: el => !el.DeletedFlag));
            if (param.AreaId != 0)
            {
                result = result.Where(el => el.Id == param.AreaId);
            }
            foreach (var area in result)
            {
                IEnumerable<ViolationCase> list = await _uow.ViolationCaseRepository
                    .Get(filter: el => el.Status == AppConstants.ViolationStatus.DETECTED && el.Location.AreaId == area.Id
                    , includeProperties: "Location");
                if (list != null || list.Count() != 0)
                {
                    if (param.Month != 0)
                    {
                        list = list.Where(el => el.CreatedTime.Month == param.Month);
                    }
                    area.NumberOfViolations = list.Count();
                }

            }
            Policy policy = await _uow.PolicyRepository.GetFirst();
            result = result.Where(el => el.NumberOfViolations > policy.NumberOfViolation).OrderBy(el => el.NumberOfViolations);
            foreach (var item in result)
            {
                item.ViolatedStatus = AppConstants.AreaViolated.EXCEED_POLICY;
            }
            return result;
        }
        public async Task<IEnumerable<AreaDto>> GetTopThreeAreaViolatedInMonth(ReportParam param)
        {
            IEnumerable<AreaDto> result = _mapper.Map<IEnumerable<AreaDto>>(await _uow.AreaRepository.Get(filter: el => !el.DeletedFlag));
            foreach (var area in result)
            {
                IEnumerable<ViolationCase> list = await _uow.ViolationCaseRepository
                    .Get(filter: el => el.Status == AppConstants.ViolationStatus.DETECTED && el.Location.AreaId == area.Id
                    , includeProperties: "Location");
                if (list != null || list.Count() != 0)
                {
                    if (param.Month != 0)
                    {
                        list = list.Where(el => el.CreatedTime.Month == param.Month);
                    }
                    area.NumberOfViolations = list.Count();
                }

            }
            result = result.Where(el => el.NumberOfViolations != 0).OrderByDescending(el => el.NumberOfViolations).ToList();
            if (result.Count() >= 3) 
            {
                result = result.ToList().GetRange(0, 3);
            }
            return result;
        }

        public async Task<IEnumerable<AreaDto>> GetAreaNonViolatedPolicyInMonth(ReportParam param)
        {
            IEnumerable<AreaDto> result = _mapper.Map<IEnumerable<AreaDto>>(await _uow.AreaRepository.Get(filter: el => !el.DeletedFlag));
            if (param.AreaId != 0)
            {
                result = result.Where(el => el.Id == param.AreaId);
            }
            foreach (var area in result)
            {
                IEnumerable<ViolationCase> list = await _uow.ViolationCaseRepository
                    .Get(filter: el => el.Status == AppConstants.ViolationStatus.DETECTED && el.Location.AreaId == area.Id
                    , includeProperties: "Location");
                if (list != null)
                {
                    if (param.Month != 0)
                    {
                        list = list.Where(el => el.CreatedTime.Month == param.Month);
                    }
                    area.NumberOfViolations = list.Count();
                }

            }
            Policy policy = await _uow.PolicyRepository.GetFirst();
            result = result.Where(el => el.NumberOfViolations <= policy.NumberOfViolation).OrderBy(el => el.NumberOfViolations);
            foreach (var item in result)
            {
               if (item.NumberOfViolations == policy.NumberOfViolation) item.ViolatedStatus = AppConstants.AreaViolated.EQUAL_TO_POLICY;
            }
            return result;
        }
    }
}
