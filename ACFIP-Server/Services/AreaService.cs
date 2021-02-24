using ACFIP_Server.Datasets.Area;
using ACFIP_Server.Repositories;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ACFIP_Server.Services.Area
{
    public interface IAreaService
    {
        Task<List<AreaDataset>> GetAll();
        Task<AreaDataset> Create(AreaCreateDataset dataset);
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

        public async Task<AreaDataset> Create(AreaCreateDataset dataset)
        {
            Models.Area area = new Models.Area() { Description = dataset.Description };
            _uow.AreaRepo.Insert(area);
            if (await _uow.CommitAsync() > 0)
            {
                return _mapper.Map<AreaDataset>(area);
            }
            return null;
        }

        public async Task<List<AreaDataset>> GetAll()
        {
            IEnumerable<Models.Area> areas = await _uow.AreaRepo.Get(filter: a => !a.DeletedFlag);
            foreach (Models.Area area in areas)
            {
                IEnumerable<Models.Camera> cams = await _uow.CameraRepo.Get(filter: c => c.AreaId == area.Id && !c.DeletedFlag, includeProperties: "Config");
                area.Cameras = cams.ToList();
            }
            List<AreaDataset> result = _mapper.Map<List<AreaDataset>>(areas);
            return result;
        }
    }
}
