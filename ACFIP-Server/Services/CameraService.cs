using ACFIP_Server.Datasets.Camera;
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

        public async Task<List<CameraDataset>> Get(bool isActive)
        {
            IEnumerable<Models.Camera> list = await _uow.CameraRepo.Get(filter: c => c.IsActive && !c.DeletedFlag && c.AreaId != null);
            return _mapper.Map<List<CameraDataset>>(list);
        }
    }
}
