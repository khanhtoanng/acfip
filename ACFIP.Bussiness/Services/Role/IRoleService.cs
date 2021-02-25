using ACFIP.Data.Dtos.Role;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ACFIP.Bussiness.Services.Role
{
    public interface IRoleService
    {
        public Task<IEnumerable<RoleDto>> GetAllRoles();

    }
}
