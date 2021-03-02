using ACFIP_Server.Datasets;
using ACFIP_Server.Helpers;
using ACFIP_Server.Services.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ACFIP_Server.Controllers
{
    [Route("api/v1/authentication")]
    [ApiVersion("1.0")]
    [ApiController]
    public class AuthenticationController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly AppConfiguration _config;
        public AuthenticationController(IAccountService accountService, AppConfiguration config)
        {
            _accountService = accountService;
            _config = config;
        }
        [AllowAnonymous]
        [HttpPost("token")]
        public async Task<IActionResult> Login([FromBody] LoginDataset param)
        {
            // validate id and password
            // ....
            // call service
            AccountDataset result = await _accountService.Login(param);
            if (result != null)
            {
                var claims = new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Sub, result.Id.ToString()),
                        new Claim(ClaimTypes.Role, result.Role.Name),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    };

                var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_config.JwtSecret));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(_config.Issuer,
                                                    _config.Audience,
                                                    claims,
                                                    // expires: DateTime.Now.AddSeconds(55 * 60),
                                                    signingCredentials: creds);
                return Ok(new
                {
                    id = result.Id,
                    role = result.Role.Name,
                    tokenType = "bearer",
                    createAt = DateTime.UtcNow,
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }
            return Unauthorized(new { message = "id or password is incorrect" });
        }
    }
}
