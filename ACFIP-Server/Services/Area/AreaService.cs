using ACFIP_Server.Datasets.Area;
using ACFIP_Server.Repositories;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ACFIP_Server.Services.Area
{
    public class AreaService : IAreaService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        public AreaService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task<List<AreaDataset>> GetAll()
        {
            IEnumerable<Models.Area> areas = await _uow.AreaRepo.Get(filter: a => !a.DeletedFlag,includeProperties: "Cameras");
            List<AreaDataset> result = _mapper.Map<List<AreaDataset>>(areas);
            return result;
        }
    }
}
