
using ACFIP.Bussiness.Services.GuardService;
using ACFIP.Data.Dtos.Guard;
using ACFIP.Data.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ACFIP.Core.Controllers
{
    [Route("api/v1/guards")]
    [ApiController]
    public class GuardController : ControllerBase
    {
        private readonly IGuardService _guardService;

        public GuardController(IGuardService guardService)
        {
            _guardService = guardService;
        }

        [Authorize(Roles = AppConstants.Role.Monitor.NAME + "," + AppConstants.Role.Manager.NAME)]

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _guardService.GetAll();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [Authorize(Roles = AppConstants.Role.Monitor.NAME + "," + AppConstants.Role.Manager.NAME)]
        [HttpGet("number-of-guard")]
        public async Task<IActionResult> CountAllGuards()
        {
            var result = await _guardService.CountAllGuards();
            return Ok(result);
        }
        [Authorize(Roles = AppConstants.Role.Monitor.NAME + "," + AppConstants.Role.Manager.NAME)]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] List<GuardCreateParam> listParam)
        {
            try
            {
                var result = await _guardService.CreateGuards(listParam);
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
    }
}
