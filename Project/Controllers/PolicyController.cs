using ACFIP.Bussiness.Services.PolicyService;
using ACFIP.Data.Dtos.Policy;
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
    [Route("api/policy")]
    [ApiController]
    public class PolicyController : ControllerBase
    {
        private readonly IPolicyService _policyService;

        public PolicyController(IPolicyService policyService)
        {
            _policyService = policyService;
        }
        [HttpGet]
        //[Authorize(Roles = AppConstants.Role.Manager.NAME )]
        public async Task<IActionResult> Get()
        {
            var result = await _policyService.GetFirstPolicy();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpPost]
        //[Authorize(Roles = AppConstants.Role.Manager.NAME)]
        public async Task<IActionResult> Post([FromBody] PolicyRequestParam param)
        {
            var result = await _policyService.AddPolicy(param);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
