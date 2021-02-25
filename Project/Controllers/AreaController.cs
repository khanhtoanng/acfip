using ACFIP.Bussiness.Services.AreaService;
using ACFIP.Data.Dtos;
using ACFIP.Data.Dtos.Area;
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
    [Route("api/v1/areas")]
    [ApiVersion("1.0")]
    [ApiController]
    public class AreaController : ControllerBase
    {
        private readonly IAreaService _areaService;

        public AreaController(IAreaService areaService)
        {
            _areaService = areaService;
        }
        [Authorize(Roles = AppConstants.Role.Monitor.NAME)]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _areaService.GetAllArea();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [Authorize(Roles = AppConstants.Role.Monitor.NAME)]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AreaCreateParam param)
        {
            var result = await _areaService.CreateArea(param);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

    }
}
