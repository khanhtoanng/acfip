using ACFIP_Server.Datasets;
using ACFIP_Server.Models;
using ACFIP_Server.Repositories;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ACFIP_Server.Services.Camera
{
    public interface ICameraService
    {
        Task<CameraDataset> CreateCamera(CameraDataset dataset);
        Task<GroupCamDataset> CreateGroupCam(GroupCreateDataset dataset);
        Task<List<GroupCamDataset>> GetGroups(int areaId);
        Task<bool> UpdateStatus(int camId, bool status);
    }
    public class CameraService : ICameraService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        public CameraService(IUnitOfWork uow, IMapper mapper)
        {
            _mapper = mapper;
            _uow = uow;
        }

        public async Task<CameraDataset> CreateCamera(CameraDataset dataset)
        {
            Models.Camera cam = new Models.Camera()
            {
                Name = dataset.Name,
                GroupId = dataset.GroupId,
                ConnectionString = dataset.ConnectionString
            };
            if (dataset.ConfigId != null)
            {
                cam.ConfigId = dataset.ConfigId.GetValueOrDefault();
            }
            else
            {
                CameraConfiguration config = new CameraConfiguration()
                {
                    Angle = dataset.Angle,
                    Height = dataset.Height
                };
                _uow.ConfigRepo.Insert(config);
                await _uow.CommitAsync();
                cam.ConfigId = config.Id;
            }
            _uow.CameraRepo.Insert(cam);
            if (await _uow.CommitAsync() > 0)
            {
                return _mapper.Map<CameraDataset>(await _uow.CameraRepo.GetFirst(filter: c => c.Id == cam.Id, includeProperties: "GroupCamera"));
            }
            return null;
        }

        public async Task<GroupCamDataset> CreateGroupCam(GroupCreateDataset dataset)
        {
            Models.GroupCamera groupCamera = new GroupCamera()
            {
                AreaId = dataset.AreaId,
                Description = dataset.Description
            };
            _uow.GroupCameraRepo.Insert(groupCamera);
            if (await _uow.CommitAsync() > 0)
            {
                return _mapper.Map<GroupCamDataset>(groupCamera);
            }
            return null;
        }

        public async Task<List<GroupCamDataset>> GetGroups(int areaId)
        {
            return _mapper.Map<List<GroupCamDataset>>(await _uow.GroupCameraRepo.Get(filter: t => !t.DeletedFlag && t.AreaId == areaId));
        }

        public async Task<bool> UpdateStatus(int camId, bool status)
        {
            Models.Camera cam = await _uow.CameraRepo.GetById(camId);
            cam.IsActive = status;
            if (await _uow.CommitAsync() > 0)
            {
                return true;
            }
            return false;
        }
    }
}
