using ACFIP_Server.Datasets;
using ACFIP_Server.Services.Camera;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ACFIP_Server.Controllers
{
    [Route("api/v1/cameras")]
    [ApiVersion("1.0")]
    [ApiController]
    public class CameraController : Controller
    {
        private readonly ICameraService _cameraService;
        public CameraController(ICameraService cameraService)
        {
            _cameraService = cameraService;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Create(CameraDataset dataset)
        {
            var result = await _cameraService.CreateCamera(dataset);
            if (result != null)
            {
                return Created("", result);
            }
            return BadRequest();
        }

        [AllowAnonymous]
        [HttpPut("{id}/status")]
        public async Task<IActionResult> UpdateStatus([FromRoute] int id,[FromBody] CameraUpdateDataset dataset)
        {
            if (id != dataset.CamId) return BadRequest();
            await _cameraService.UpdateStatus(id, dataset.Status);
            return NoContent();
        }
    }
}
