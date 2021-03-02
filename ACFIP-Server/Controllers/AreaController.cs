using ACFIP_Server.Datasets;
using ACFIP_Server.Services.Area;
using ACFIP_Server.Services.Camera;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ACFIP_Server.Controllers
{
    [Route("api/v1/areas")]
    [ApiVersion("1.0")]
    [ApiController]
    public class AreaController : Controller
    {
        private readonly IAreaService _areaService;
        private readonly ICameraService _cameraService;
        public AreaController(IAreaService areaService, ICameraService cameraService)
        {
            _areaService = areaService;
            _cameraService = cameraService;
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
            AreaDataset result = await _areaService.CreateArea(dataset);
            if (result != null)
            {
                return Created("", result);
            }
            return BadRequest();
        }
        [AllowAnonymous]
        [HttpGet("{id}/groups")]
        public async Task<IActionResult> GetGroups([FromRoute]int id)
        {
            return Ok(await _cameraService.GetGroups(id));
        }
    }
}
