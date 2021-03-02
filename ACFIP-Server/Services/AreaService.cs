using ACFIP_Server.Datasets;
using ACFIP_Server.Repositories;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ACFIP_Server.Services.Area
{
    public interface IAreaService
    {
        Task<List<AreaDataset>> GetAll();
        Task<AreaDataset> CreateArea(AreaCreateDataset dataset);
    }

    public class AreaService : IAreaService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        public AreaService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<AreaDataset> CreateArea(AreaCreateDataset dataset)
        {
            Models.Area area = new Models.Area() { Name = dataset.Name, Description = dataset.Description };
            _uow.AreaRepo.Insert(area);
            if (await _uow.CommitAsync() > 0)
            {
                _uow.GroupCameraRepo.Insert(new Models.GroupCamera() { AreaId = area.Id, Description = "Default group" });
                await _uow.CommitAsync();
                return _mapper.Map<AreaDataset>(area);
            }
            return null;
        }

        public async Task<List<AreaDataset>> GetAll()
        {
            List<AreaDataset> areas = _mapper.Map < List < AreaDataset >> (await _uow.AreaRepo.Get(filter: a => !a.DeletedFlag));
            foreach (AreaDataset area in areas)
            {
                area.Cameras = _mapper.Map<List<CameraDataset>>(await _uow.CameraRepo.Get(includeProperties: "GroupCamera,Config", filter: c => !c.DeletedFlag && c.GroupCamera.AreaId == area.Id));
            }
            return areas;
        }
    }
}
