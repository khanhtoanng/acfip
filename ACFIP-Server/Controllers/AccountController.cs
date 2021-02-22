using ACFIP_Server.Datasets.Account;
using ACFIP_Server.Helpers;
using ACFIP_Server.Services.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ACFIP_Server.Controllers
{
    [Route("api/v1/accounts")]
    [ApiVersion("1.0")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly AppConfiguration _config;
        public AccountController(IAccountService accountService, AppConfiguration config)
        {
            _accountService = accountService;
            _config = config;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAccount(int id)
        {
            AccountDataset account = await _accountService.GetAccount(id);
            if (account != null)
            {
                return Ok(account);
            }
            return NotFound();
        }

        //[Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> CreateAccount([FromBody] RegisterDataset param)
        {
            // validate param
            // ... 

            AccountDataset account = await _accountService.Create(param);
            return CreatedAtAction(nameof(GetAccount), new { id = account.Id }, account);
        }
    }
}
