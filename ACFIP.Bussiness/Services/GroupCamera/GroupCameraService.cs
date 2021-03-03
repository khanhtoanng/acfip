using ACFIP.Data.Dtos.GroupCamera;
using ACFIP.Data.UnitOfWork;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ACFIP.Bussiness.Services.GroupCamera
{
    public class GroupCameraService : IGroupCameraService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public GroupCameraService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<GroupCameraDto> CreateGroupCamera(GroupCameraCreateParam param)
        {
            Data.Models.GroupCamera camera = new Data.Models.GroupCamera() { AreaId = param.AreaId, Description = param.Description };
            _uow.GroupCameraRepository.Add(camera);
            return await _uow.SaveAsync() > 0 ? _mapper.Map<GroupCameraDto>(camera) : null;
        }

        public async Task<IEnumerable<GroupCameraDto>> GetAllGroupCamera(int areaId)
        {
            return _mapper.Map<IEnumerable<GroupCameraDto>>(await _uow.GroupCameraRepository.Get(filter: el => !el.DeletedFlag && el.AreaId == areaId));
        }
    }
}
