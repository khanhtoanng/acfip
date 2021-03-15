using ACFIP.Bussiness.Services.Account;
using ACFIP.Bussiness.Services.EmailSender;
using ACFIP.Data.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ACFIP.Core.Controllers
{
    [Route("api/email-sender")]
    [ApiController]
    public class EmailSenderController : ControllerBase
    {
        private readonly IEmailSenderService _emailSenderService;
        private readonly IAccountService _accountService;

        public EmailSenderController(IEmailSenderService emailSenderService, IAccountService accountService)
        {
            _emailSenderService = emailSenderService;
            _accountService = accountService;
        }
        [HttpGet]
        public async Task<bool> SendEmail()
        {
            List<string> listEmailAccountManager = (await _accountService.GetAsync(filter: el => el.RoleId == AppConstants.Role.Manager.ID && !el.DeletedFlag)).Select(el => el.Email).ToList();
            IEnumerable<string>  listEmail = listEmailAccountManager.ToArray();
            var message = new Message(listEmail, "Report Violations", @"
                      <html>
                      <body>
                      <h2>Dear Manager,</h2>
                      <p>This is a automatic email </p><br/>
                      <h4  style='color:red;'>Some areas have violated the policy.</h4>
                      <h5>Sincerely</h5>
                      </body>
                      </html>
                     ");
            return await _emailSenderService.SendEmailAsync(message);
        }

    }
}
