using ACFIP.Data.Dtos.Location;
using ACFIP.Data.UnitOfWork;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ACFIP.Bussiness.Services.Location
{
    public class LocationService : ILocationService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public LocationService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<LocationDto> CreateLocation(LocationCreateParam param)
        {
            Data.Models.Location camera = new Data.Models.Location() { AreaId = param.AreaId, Description = param.Description };
            _uow.LocationRepository.Add(camera);
            return await _uow.SaveAsync() > 0 ? _mapper.Map<LocationDto>(camera) : null;
        }

        public async Task<LocationDto> DeleteLocation(int id)
        {
            Data.Models.Location Location = await _uow.LocationRepository.GetById(id);
            if (Location != null)
            {
                Location.DeletedFlag = true;
                Location.AreaId = null;
                _uow.LocationRepository.Update(Location);
            }
            return await _uow.SaveAsync() > 0 ? _mapper.Map<LocationDto>(Location) : null;
        }

        public async Task<IEnumerable<LocationDto>> GetAllLocation(int areaId)
        {
            return _mapper.Map<IEnumerable<LocationDto>>(await _uow.LocationRepository.Get(filter: el => !el.DeletedFlag && el.AreaId == areaId));
        }

        public async Task<LocationDto> UpdateLocation(LocationUpdateParam param)
        {
            Data.Models.Location Location = await _uow.LocationRepository.GetById(param.Id);
            if (Location != null) 
            {
                Location.Description = param.Description;
                Location.AreaId = param.AreaId == null ? Location.AreaId : param.AreaId;
            }
            return await _uow.SaveAsync() > 0 ? _mapper.Map<LocationDto>(Location) : null;
        }
    }
}
