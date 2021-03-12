using ACFIP.Data.Dtos.Guard;
using ACFIP.Data.UnitOfWork;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ACFIP.Bussiness.Services.GuardService
{
    public class GuardService : IGuardService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public GuardService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GuardDto>> GetAll()
        {
            return _mapper.Map<IEnumerable<GuardDto>>(await _uow.GuardRepository.Get());
        }

    }
}
