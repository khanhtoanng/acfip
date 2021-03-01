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
            return await _uow.SaveAsync() > 0 ? _mapper.Map<AreaDto>(area) : null;
        }

        public async Task<IEnumerable<AreaDto>> GetAllAreaForFilter()
        {
            return _mapper.Map<IEnumerable<AreaDto>>(await _uow.AreaRepository.Get(filter: el => !el.DeletedFlag));
        }

        public async Task<IEnumerable<AreaDto>> GetAllArea()
        {
            IEnumerable<Area> listArea = await _uow.AreaRepository.Get(filter: el => !el.DeletedFlag,includeProperties: "GroupCameras");
            foreach (Area area in listArea)
            {
                foreach (GroupCamera group in area.GroupCameras)
                {
                    group.Cameras = (await _uow.CameraRepository.Get(filter: el => el.GroupId == group.Id && !el.DeletedFlag, includeProperties: "Config")).ToList();
                }
            }
            return _mapper.Map<IEnumerable<AreaDto>>(listArea);
        }

        public async Task<AreaDto> DeleteArea(int id)
        {
            Area area = await _uow.AreaRepository.GetById(id);
            area.DeletedFlag = true;
            _uow.AreaRepository.Update(area);
            return await _uow.SaveAsync() > 0 ? _mapper.Map<AreaDto>(area) : null;
        }
    }
}
