using ACFIP.Bussiness.Services.AuthenticationService;
using ACFIP.Core.Settings;
using ACFIP.Data.Dtos.Account;
using ACFIP.Data.Dtos.Accounts;
using ACFIP.Data.Helpers;
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

namespace ACFIP.Core.Controllers
{
    [Route("api/v1/authentication")]
    [ApiVersion("1.0")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        private AppSettings _appSettings;

        public AuthenticationController(IAuthenticationService authenticationService, AppSettings appSettings)
        {
            _authenticationService = authenticationService;
            _appSettings = appSettings;
        }

        [AllowAnonymous]
        [HttpPost("web")]
        public async Task<IActionResult> Login(AccountLoginParam param)
        {
            try
            {
                AccountDto accountDto = await _authenticationService.LoginWeb(param);
                if (accountDto != null && accountDto.Role.Id != AppConstants.Role.Monitor.ID)
                {
                    var claims = new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Sub, accountDto.Id.ToString()),
                        new Claim(ClaimTypes.Role, accountDto.Role.Name),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    };
                    var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_appSettings.JwtSecret));
                    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        _appSettings.Issuer,
                        _appSettings.Audience,
                        claims,
                        signingCredentials: creds
                        );
                    return Ok(
                        new
                        {
                            id = accountDto.Id,
                            role = accountDto.Role.Name,
                            tokenType = "bearer",
                            createAt = DateTime.UtcNow,
                            token = new JwtSecurityTokenHandler().WriteToken(token)
                        });
                }
                else
                {
                    return Unauthorized(new { message = "id or password is incorrect" });
                }

            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }

        }
        [AllowAnonymous]
        [HttpPost("destop")]
        public async Task<IActionResult> LoginDestop(AccountLoginParam param)
        {
            try
            {
                AccountDto accountDto = await _authenticationService.LoginDestop(param);
                if (accountDto != null && accountDto.Role.Id == AppConstants.Role.Monitor.ID)
                {
                    var claims = new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Sub, accountDto.Id.ToString()),
                        new Claim(ClaimTypes.Role, accountDto.Role.Name),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    };
                    var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_appSettings.JwtSecret));
                    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        _appSettings.Issuer,
                        _appSettings.Audience,
                        claims,
                        signingCredentials: creds
                        );
                    return Ok(
                        new
                        {
                            id = accountDto.Id,
                            role = accountDto.Role.Name,
                            tokenType = "bearer",
                            createAt = DateTime.UtcNow,
                            token = new JwtSecurityTokenHandler().WriteToken(token)
                        });
                }
                else
                {
                    return Unauthorized(new { message = "id or password is incorrect" });
                }

            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }
    } 
}
