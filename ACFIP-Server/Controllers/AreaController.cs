using ACFIP_Server.Services.Area;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ACFIP_Server.Controllers
{
    [Route("api/v1/areas")]
    [ApiVersion("1.0")]
    [ApiController]
    public class AreaController : Controller
    {
        private readonly IAreaService _areaService;
        public AreaController(IAreaService areaService)
        {
            _areaService = areaService;
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAreas()
        {
            return Ok(await _areaService.GetAll());
        }
    }
}
