using ACFIP.Bussiness.Services.ViolationType;
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
    [Route("api/v1/violation-types")]
    [ApiVersion("1.0")]
    [ApiController]
    public class ViolationTypeController : ControllerBase
    {
        private readonly IViolationTypeService _violationTypeService;
        public ViolationTypeController(IViolationTypeService violationTypeService)
        {
            _violationTypeService = violationTypeService;
        }
        [Authorize(Roles = AppConstants.Role.Monitor.NAME + "," + AppConstants.Role.Manager.NAME)]
        [HttpGet]
        public async Task<IActionResult> GetAllViolationType()
        {
            var result = await _violationTypeService.GetAllTypes();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
