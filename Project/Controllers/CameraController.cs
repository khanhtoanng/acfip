using ACFIP.Bussiness.Services.CameraService;
using ACFIP.Data.Dtos;
using ACFIP.Data.Dtos.Camera;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ACFIP.Core.Controllers
{
    [Route("api/v1/camera")]
    [ApiController]
    public class CameraController : ControllerBase
    {
        private readonly ICameraService _cameraService;

        public CameraController(ICameraService cameraService)
        {
            _cameraService = cameraService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] CameraRequestParam param)
        {
            var result = await _cameraService.GetAllCamera(param);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
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
        [HttpPost]
        public async Task<IActionResult> CreateAccount([FromBody] CameraCreateParam param)
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
        public async Task<IActionResult> UpdateStatusCamera([FromBody] CameraStatus param)
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
