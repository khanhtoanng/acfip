using ACFIP_Server.Datasets.Camera;
using ACFIP_Server.Services.Camera;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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
        [HttpGet]
        public async Task<IActionResult> Get(bool isActive)
        {
            return Ok(await _cameraService.Get(isActive));
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Create(CameraDataset dataset)
        {
            var result = await _cameraService.Create(dataset);
            if (result != null)
            {
                return Created("", result);
            }
            return BadRequest();
        }
    }
}
