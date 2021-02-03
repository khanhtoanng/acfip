using ACFIP.Data.Dtos;
using ACFIP.Data.Dtos.Area;
using ACFIP.Data.Models;
using ACFIP.Data.UnitOfWork;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ACFIP.Bussiness.Service.AreaService
{
    public class AreaService : IAreaService
    {
        private IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public AreaService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AreaDto>> GetAllArea(PagingRequestParam param)
        {
            IEnumerable<Area> listArea = await _uow.AreaRepository.Get(pageIndex: param.PageIndex, pageSize: param.PageSize, includeProperties: "Cameras");
            return _mapper.Map<IEnumerable<AreaDto>>(listArea);
        }
    }
}
