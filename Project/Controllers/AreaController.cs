using ACFIP.Bussiness.Services.AreaService;
using ACFIP.Data.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ACFIP.Core.Controllers
{
    [Route("api/v1/areas")]
    [ApiController]
    public class AreaController : ControllerBase
    {
        private readonly IAreaService _areaService;

        public AreaController(IAreaService areaService)
        {
            _areaService = areaService;
        }
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] PagingRequestParam param)
        {
            var result = await _areaService.GetAllArea(param);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
 
    }
}
