using ACFIP.Bussiness.Service.AuthenticationService;
using ACFIP.Data.Dtos.Account;
using ACFIP.Data.Dtos.Accounts;
using ACFIP.Data.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Project.Controller
{
    [Route("api/v1/authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(AccountRequestParam param)
        {
            try
            {
                AccountDto accountDto = await _authenticationService.Login(param);
                if (accountDto != null)
                {
                    var claims = new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Sub, accountDto.Id.ToString()),
                        new Claim(ClaimTypes.Role, accountDto.Role.Name),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    };
                    var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(AppSettings.Settings.JwtSecret));
                    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        AppSettings.Settings.Issuer,
                        AppSettings.Settings.Audience,
                        claims,
                        signingCredentials: creds
                        );
                    return Ok(
                        new
                        {
                            Id = accountDto.Id,
                            Role = accountDto.Role.Name,
                            Token = new JwtSecurityTokenHandler().WriteToken(token)
                        });
                }
                else
                {
                    return Forbid();
                }

            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }
    }
}
