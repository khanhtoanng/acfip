using ACFIP.Data.Dtos.Role;
using ACFIP.Data.Helpers;
using ACFIP.Data.UnitOfWork;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ACFIP.Bussiness.Services.Role
{
   public  class RoleService : IRoleService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public RoleService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RoleDto>> GetAllRoles()
        {
            return _mapper.Map<IEnumerable<RoleDto>>(await _uow.RoleRepository.Get(filter: el => el.Id != AppConstants.Role.Admin.ID));
        }
    }
}
