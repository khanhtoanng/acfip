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
        [Authorize(Roles = AppConstants.Role.Monitor.NAME)]
        [HttpGet]
        public async Task<IActionResult> Get(bool? isActive)
        {
            var result = await _cameraService.GetAllCamera(isActive);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Authorize(Roles = AppConstants.Role.Monitor.NAME)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDetailCamera([FromRoute] int id)
        {
            var result = await _cameraService.GetDetailCamera(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Authorize(Roles = AppConstants.Role.Monitor.NAME)]
        [HttpDelete("{id}")]
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

        [Authorize(Roles = AppConstants.Role.Monitor.NAME)]
        [HttpPut]
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

        [Authorize(Roles = AppConstants.Role.Monitor.NAME)]
        [HttpPost]
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

        [Authorize(Roles = AppConstants.Role.Monitor.NAME)]
        [HttpPut("{id}/status")]
        public async Task<IActionResult> UpdateStatusCamera([FromRoute] int id,[FromBody] CameraActivationParam param)
        {
            try
            {
                var result = await _cameraService.UpdateStatusCamera(id,param);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }

        }

    }
}
