﻿using ACFIP.Data.Dtos;
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
                area.Cameras = _mapper.Map<List<CameraDto>>
                    (await _uow.CameraRepository.Get(filter: el => !el.DeletedFlag && el.Location.AreaId == area.Id, includeProperties: "Location,Config"));
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
            return await _uow.SaveAsync() > 0 ?  _mapper.Map<AreaDto>(area) : null;
        }
    }
}
