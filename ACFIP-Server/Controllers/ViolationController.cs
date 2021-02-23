using ACFIP_Server.Datasets.ViolationCase;
using ACFIP_Server.Services.Violation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ACFIP_Server.Controllers
{
    [Route("api/v1/violation-cases")]
    [ApiVersion("1.0")]
    [ApiController]
    public class ViolationController : Controller
    {
        private readonly IViolationService _violationService;
        public ViolationController(IViolationService violationService)
        {
            _violationService = violationService;
        }
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOne([FromRoute] int id)
        {
            return Ok(await _violationService.GetOne(id));
        }
        [AllowAnonymous]
        [HttpGet("latest")]
        public async Task<IActionResult> GetLatest(int cameraId)
        {
            return Ok(await _violationService.GetLatest(cameraId));
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> CreateViolationCase([FromBody] ViolationDataset violationDataset)
        {
            ViolationDataset result = await _violationService.Create(violationDataset);
            if (result != null)
            {
                return CreatedAtAction(nameof(GetOne), new { id = result.Id }, result);
            }
            return BadRequest();
        }
    }
}
