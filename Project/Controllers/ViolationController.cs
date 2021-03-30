using ACFIP.Bussiness.Services.ViolationCaseService;
using ACFIP.Data.Dtos;
using ACFIP.Data.Dtos.ViolationCase;
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
    [Route("api/v1/violations")]
    [ApiVersion("1.0")]
    [ApiController]
    public class ViolationController : ControllerBase
    {
        private readonly IViolationCaseService _violationCaseService;

        public ViolationController(IViolationCaseService violationCaseService)
        {
            _violationCaseService = violationCaseService;
        }


        [Authorize(Roles = AppConstants.Role.Monitor.NAME
                            + ","
                            + AppConstants.Role.Manager.NAME)]
        [HttpGet]
        public async Task<IActionResult> GetAllViolation([FromQuery] ViolationRequestParam param)
        {
            var result = await _violationCaseService.GetAllViolation(param);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("non-view")]
        [Authorize(Roles = AppConstants.Role.Monitor.NAME
                          + ","
                          + AppConstants.Role.Manager.NAME)]
        public async Task<IActionResult> GetNonViewViolation()
        {
            var result = await _violationCaseService.GetNonViewViolations();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = AppConstants.Role.Monitor.NAME
                            + ","
                            + AppConstants.Role.Manager.NAME)]
        public async Task<IActionResult> GetDetailViolation(int id)
        {
            var result = await _violationCaseService.GetDetailViolation(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Authorize(Roles = AppConstants.Role.Monitor.NAME
                            + ","
                            + AppConstants.Role.Manager.NAME)]
        [HttpPost]
        public async Task<IActionResult> CreateViolation(ViolationCreateParam param)
        {
            try
            {
                var result = await _violationCaseService.CreateViolation(param);
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

        [Authorize(Roles = AppConstants.Role.Monitor.NAME
                            + ","
                            + AppConstants.Role.Manager.NAME)]
        [HttpGet("latest")]
        public async Task<IActionResult> GetLatest(int locationId)
        {
            var result = await _violationCaseService.GetLast(locationId);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Authorize(Roles = AppConstants.Role.Monitor.NAME
                           + ","
                           + AppConstants.Role.Manager.NAME)]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _violationCaseService.DeleteViolation(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpPut("{id}/status")]
        [Authorize(Roles = AppConstants.Role.Monitor.NAME
                           + ","
                           + AppConstants.Role.Manager.NAME)]
        public async Task<IActionResult> UpdateStatus(int id, ViolationCaseUpdateStatusParam param)
        {
            var result = await _violationCaseService.UpdateStatus(id, param);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPut("view")]
        [Authorize(Roles = AppConstants.Role.Monitor.NAME
                          + ","
                          + AppConstants.Role.Manager.NAME)]
        public async Task<IActionResult> UpdateView(ViolationCaseupdateViewParam param)
        {
            var result = await _violationCaseService.UpdateView(param);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Authorize(Roles = AppConstants.Role.Monitor.NAME
                   + ","
                   + AppConstants.Role.Manager.NAME)]
        [HttpGet("report")]
        public async Task<IActionResult> GetViolationReport()
        {
            var result = await _violationCaseService.GetViolationReport();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("report/{month}")]
        [Authorize(Roles = AppConstants.Role.Monitor.NAME
                        + ","
                        + AppConstants.Role.Manager.NAME)]
        public async Task<IActionResult> GetViolationReportInMonth(int month)
        {
            var result = await _violationCaseService.GetViolationReportInMonth(month);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [Authorize(Roles = AppConstants.Role.Monitor.NAME
                         + ","
                         + AppConstants.Role.Manager.NAME)]
        [HttpGet("number-of-violations")]
        public async Task<IActionResult> CountAll()
        {
            var result = await _violationCaseService.CountAlViolaition();
            return Ok(result);
        }
        [Authorize(Roles = AppConstants.Role.Monitor.NAME
                          + ","
                          + AppConstants.Role.Manager.NAME)]
        [HttpGet("number-of-non-detected-violations")]
        public async Task<IActionResult> CountAllNonDetected()
        {
            var result = await _violationCaseService.CountNonDetectedViolation();
            return Ok(result);
        }
        [Authorize(Roles = AppConstants.Role.Monitor.NAME
                       + ","
                       + AppConstants.Role.Manager.NAME)]
        [HttpGet("current-month-comparation")]
        public async Task<IActionResult> CompareViolation()
        {
            var result = await _violationCaseService.CompareViolation();
            return Ok(result);
        }
    }
}
