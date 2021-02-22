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

        public async Task<IEnumerable<AreaDto>> GetAllArea(PagingRequestParam param)
        {
            IEnumerable<Area> listArea = await _uow.AreaRepository.Get(pageIndex: param.PageIndex, pageSize: param.PageSize);
            return _mapper.Map<IEnumerable<AreaDto>>(listArea);
        }

        public Task<AreaDto> GetAreaById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
