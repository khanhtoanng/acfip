using ACFIP_Server.Datasets.Camera;
using ACFIP_Server.Models;
using ACFIP_Server.Repositories;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ACFIP_Server.Services.Camera
{
    public interface ICameraService
    {
        Task<List<CameraDataset>> Get(bool isActive);
        Task<CameraDataset> Create(CameraDataset dataset);
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

        public async Task<CameraDataset> Create(CameraDataset dataset)
        {
            Models.Camera cam = new Models.Camera()
            {
                Name = dataset.Name,
                AreaId = dataset.AreaId,
                ConnectionString = dataset.ConnectionString
            };
            if (dataset.ConfigId != null)
            {
                cam.ConfigId = dataset.ConfigId.GetValueOrDefault();
            } else
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
                return _mapper.Map<CameraDataset>(cam);
            }
            return null;
        }

        public async Task<List<CameraDataset>> Get(bool isActive)
        {
            IEnumerable<Models.Camera> list = await _uow.CameraRepo.Get(filter: c => c.IsActive && !c.DeletedFlag && c.AreaId != null);
            return _mapper.Map<List<CameraDataset>>(list);
        }
    }
}
