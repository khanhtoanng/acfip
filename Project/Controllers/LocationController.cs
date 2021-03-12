using ACFIP.Bussiness.Services.Location;
using ACFIP.Data.Dtos.Location;
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
    [Route("api/v1/locations")]
    [ApiVersion("1.0")]
    [ApiController]
    public class LocationController : Controller
    {
        private readonly ILocationService _locationService;
        public LocationController(ILocationService groupService)
        {
            _locationService = groupService;
        }
        [Authorize(Roles = AppConstants.Role.Monitor.NAME + "," + AppConstants.Role.Manager.NAME)]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] LocationCreateParam param)
        {
            var result = await _locationService.CreateLocation(param);
            if (result != null)
            {
                return Created("", result);
            }
            return BadRequest();
        }
        [Authorize(Roles = AppConstants.Role.Monitor.NAME + "," + AppConstants.Role.Manager.NAME)]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _locationService.DeleteLocation(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

      
        [Authorize(Roles = AppConstants.Role.Monitor.NAME + "," + AppConstants.Role.Manager.NAME)]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] LocationUpdateParam param)
        {
            var result = await _locationService.UpdateLocation(param);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }

}
