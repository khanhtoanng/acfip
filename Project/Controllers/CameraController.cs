using ACFIP.Bussiness.Services.CameraService;
using ACFIP.Data.Dtos;
using ACFIP.Data.Dtos.Camera;
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
    [Route("api/v1/cameras")]
    [ApiVersion("1.0")]
    [ApiController]
    public class CameraController : ControllerBase
    {
        private readonly ICameraService _cameraService;

        public CameraController(ICameraService cameraService)
        {
            _cameraService = cameraService;
        }

        [HttpGet]
        //[Authorize(Roles = AppConstants.Role.Monitor.NAME)]
        public async Task<IActionResult> Get(bool isActive)
        {
            var result = await _cameraService.GetAllCamera(isActive);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpGet("{id}")]
        [Authorize(Roles = AppConstants.Role.Monitor.NAME)]
        public async Task<IActionResult> GetDetailCamera([FromRoute] int id)
        {
            var result = await _cameraService.GetDetailCamera(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = AppConstants.Role.Monitor.NAME)]
        public async Task<IActionResult> DeleteCamera([FromRoute] int id)
        {
            try
            {
                var result = await _cameraService.DeleteCamera(id);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }

        }
        [HttpPut]
        [Authorize(Roles = AppConstants.Role.Monitor.NAME)]
        public async Task<IActionResult> Update([FromBody] CameraUpdateParam param)
        {
            try
            {
                var result = await _cameraService.UpdateCamera(param);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }

        }
        [HttpPost]
        [Authorize(Roles = AppConstants.Role.Monitor.NAME)]
        public async Task<IActionResult> CreateCamera([FromBody] CameraCreateParam param)
        {
            try
            {
                var result = await _cameraService.CreateCamera(param);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }
        [HttpPut("status")]
        [Authorize(Roles = AppConstants.Role.Monitor.NAME)]
        public async Task<IActionResult> UpdateStatusCamera([FromBody] CameraActivationParam param)
        {
            try
            {
                var result = await _cameraService.UpdateStatusCamera(param);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }

        }

    }
}
