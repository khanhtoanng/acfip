using ACFIP.Bussiness.Services.AreaService;
using ACFIP.Bussiness.Services.GroupCamera;
using ACFIP.Data.Dtos;
using ACFIP.Data.Dtos.Area;
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
    [Route("api/v1/areas")]
    [ApiVersion("1.0")]
    [ApiController]
    public class AreaController : ControllerBase
    {
        private readonly IAreaService _areaService;
        private readonly IGroupCameraService _groupService;

        public AreaController(IAreaService areaService, IGroupCameraService groupService)
        {
            _areaService = areaService;
            _groupService = groupService;
        }
        [Authorize(Roles = AppConstants.Role.Monitor.NAME + "," + AppConstants.Role.Manager.NAME)]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _areaService.GetAllArea();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [Authorize(Roles = AppConstants.Role.Monitor.NAME + "," + AppConstants.Role.Manager.NAME)]
        [HttpGet("filter")]
        public async Task<IActionResult> GetAreaFilter()
        {
            var result = await _areaService.GetAllAreaForFilter();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [Authorize(Roles = AppConstants.Role.Monitor.NAME + "," + AppConstants.Role.Manager.NAME)]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AreaCreateParam param)
        {
            var result = await _areaService.CreateArea(param);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [Authorize(Roles = AppConstants.Role.Monitor.NAME + "," + AppConstants.Role.Manager.NAME)]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _areaService.DeleteArea(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Authorize(Roles = AppConstants.Role.Monitor.NAME + "," + AppConstants.Role.Manager.NAME)]
        [HttpGet("{id}/groups")]
        public async Task<IActionResult> GetGroups([FromRoute] int id)
        {
            var result = await _groupService.GetAllGroupCamera(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Authorize(Roles = AppConstants.Role.Monitor.NAME + "," + AppConstants.Role.Manager.NAME)]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] AreaUpdateParam param)
        {
            var result = await _areaService.UpdateArea(param);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
