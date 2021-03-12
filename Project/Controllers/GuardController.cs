
using ACFIP.Bussiness.Services.GuardService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ACFIP.Core.Controllers
{
    [Route("api/guards")]
    [ApiController]
    public class GuardController : ControllerBase
    {
        private readonly IGuardService _guardService;

        public GuardController(IGuardService guardService)
        {
            _guardService = guardService;
        }

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
    }
}
