using ACFIP_Server.Datasets.Area;
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
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AreaCreateDataset dataset)
        {
            AreaDataset result = await _areaService.Create(dataset);
            if (result != null)
            {
                return Created("", result);
            }
            return BadRequest();
        }
    }
}
