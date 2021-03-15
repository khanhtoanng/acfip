using ACFIP.Bussiness.Services.Account;
using ACFIP.Bussiness.Services.EmailSender;
using ACFIP.Bussiness.Services.Location;
using ACFIP.Bussiness.Services.PolicyService;
using ACFIP.Data.Dtos.Area;
using ACFIP.Data.Dtos.Policy;
using ACFIP.Data.Helpers;
using ACFIP.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ACFIP.Core.Controllers
{
    [Route("api/v1/policy")]
    [ApiController]
    public class PolicyController : ControllerBase
    {
        private readonly IPolicyService _policyService;
        private readonly IEmailSenderService _emailSenderService;
        private readonly IAccountService _accountService;
        private readonly ILocationService _locationService;


        public PolicyController(IPolicyService policyService, IEmailSenderService emailSenderService, IAccountService accountService, ILocationService locationService)
        {
            _policyService = policyService;
            _emailSenderService = emailSenderService;
            _accountService = accountService;
            _locationService = locationService;

        }
        [HttpGet]
        [Authorize(Roles = AppConstants.Role.Manager.NAME )]
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
        [Authorize(Roles = AppConstants.Role.Manager.NAME)]
        public async Task<IActionResult> Post([FromBody] PolicyRequestParam param)
        {
            try
            {
                var result = await _policyService.AddPolicy(param);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }
        [HttpGet("validation/{locationId}")]
        [Authorize(Roles = AppConstants.Role.Monitor.NAME + "," + AppConstants.Role.Manager.NAME)]
        public async Task<IActionResult> IsValidPolicy(int locationId)
        {
            AreaDto invalidArea = await _policyService.IsInValidArea(locationId);
            if (invalidArea == null)
            {
                return NotFound();
            }
            List<string> listEmailAccountManager = (await _accountService.GetAsync(filter: el => el.RoleId == AppConstants.Role.Manager.ID && !el.DeletedFlag)).Select(el => el.Email).ToList();
            IEnumerable<string> listEmail = listEmailAccountManager.ToArray();
            var message = new Message(listEmail, "Report Violations", string.Format(@"
                      <html>
                      <body>
                      <h2>Dear Manager,</h2>
                      <p>This is a automatic email </p><br/>
                      <h4  style='color:red;'>Area Name: {0} have violated the policy.</h4>
                      <h4>Please check violations with <a href=""https://acfip-server-backup.azurewebsites.net/swagger/index.html"">ACFIP System Link</a> </h4>
                      <h5>Sincerely</h5>
                      </body>
                      </html>
                     ", invalidArea.Name));
            await _emailSenderService.SendEmailAsync(message);
            return Ok(invalidArea);
        }

    }
}
