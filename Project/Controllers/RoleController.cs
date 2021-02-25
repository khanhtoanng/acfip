using ACFIP.Bussiness.Services.Role;
using ACFIP.Data.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ACFIP.Core.Controllers
{
    [Route("api/roles")]
    [ApiVersion("1.0")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }
        [Authorize(Roles = AppConstants.Role.Admin.NAME+ "," + AppConstants.Role.Manager.NAME)]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _roleService.GetAllRoles();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
