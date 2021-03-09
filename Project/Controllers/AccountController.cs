using ACFIP.Bussiness.Services.Account;
using ACFIP.Data.Dtos;
using ACFIP.Data.Dtos.Account;
using ACFIP.Data.Dtos.Accounts;
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
    [Route("api/v1/accounts")]
    [ApiVersion("1.0")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        [HttpGet]
        [Authorize(Roles = AppConstants.Role.Manager.NAME + "," + AppConstants.Role.Admin.NAME)]
        public async Task<IActionResult> Get([FromQuery] PagingRequestParam param)
        {
            var result = await _accountService.GetAsync(pageIndex: param.PageIndex, pageSize: param.PageSize, includeProperties: "Role");
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpGet("{id}")]
        [Authorize(Roles = AppConstants.Role.Manager.NAME + "," + AppConstants.Role.Admin.NAME)]
        public async Task<IActionResult> GetById([FromRoute] string id)
        {
            var result = await _accountService.GetFirst(filter: el => el.Id == id, includeProperties: "Role");
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = AppConstants.Role.Manager.NAME + "," + AppConstants.Role.Admin.NAME)]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            var result = await _accountService.DeleteAccount(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpPut("password")]
        [Authorize(Roles = AppConstants.Role.Manager.NAME
                    + "," + AppConstants.Role.Admin.NAME
                    + "," + AppConstants.Role.Monitor.NAME)]
        public async Task<IActionResult> ChangePassword([FromBody] AccountPasswordParam param)
        {
            var result = await _accountService.ChangePassword(param);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpPost]
        [Authorize(Roles = AppConstants.Role.Manager.NAME + "," + AppConstants.Role.Admin.NAME)]
        public async Task<IActionResult> CreateAccount([FromBody] AccountCreateParam param)
        {
            var result = await _accountService.CreateAccount(param);
            if (result == null)
            {
                return NotFound("Password is not verify");
            }
            return Ok(result);

        }
        [HttpPut("{id}/status")]
        [Authorize(Roles = AppConstants.Role.Manager.NAME + "," + AppConstants.Role.Admin.NAME)]
        public async Task<IActionResult> UpdateStatusAccount(int id , [FromBody] AccountActivationParam param)
        {
            try
            {
                var result = await _accountService.UpdateStatusAccount(id,param);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }

        }
    }
}
