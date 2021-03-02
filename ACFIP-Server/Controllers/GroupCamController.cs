using ACFIP_Server.Datasets;
using ACFIP_Server.Services.Camera;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ACFIP_Server.Controllers
{
    [Route("api/v1/cam-groups")]
    [ApiVersion("1.0")]
    [ApiController]
    public class GroupCamController : Controller
    {
        private readonly ICameraService _cameraService;
        public GroupCamController(ICameraService cameraService)
        {
            _cameraService = cameraService;
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] GroupCreateDataset dataset)
        {
            var result = await _cameraService.CreateGroupCam(dataset);
            if (result != null)
            {
                return Created("", result);
            }
            return BadRequest();
        }
    }
}
