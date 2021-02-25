using ACFIP.Data.Dtos.ViolationType;
using ACFIP.Data.UnitOfWork;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ACFIP.Bussiness.Services.ViolationType
{
    public class ViolationTypeService: IViolationTypeService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public ViolationTypeService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ViolationTypeDto>> GetAllTypes()
        {
            return _mapper.Map<IEnumerable<ViolationTypeDto>>(await _uow.ViolationTypeRepository.Get());
        }
    }
}
