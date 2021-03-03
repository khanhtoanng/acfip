using ACFIP.Bussiness.Services.GroupCamera;
using ACFIP.Data.Dtos.GroupCamera;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ACFIP.Core.Controllers
{
    [Route("api/v1/cam-groups")]
    [ApiVersion("1.0")]
    [ApiController]
    public class GroupCamController : Controller
    {
        private readonly IGroupCameraService _groupService;
        public GroupCamController(IGroupCameraService groupService)
        {
            _groupService = groupService;
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] GroupCameraCreateParam param)
        {
            var result = await _groupService.CreateGroupCamera(param);
            if (result != null)
            {
                return Created("", result);
            }
            return BadRequest();
        }
    }
}
