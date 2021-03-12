using ACFIP.Data.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ACFIP.Bussiness.Services.EmailSender
{
    public interface IEmailSenderService
    {
        Task<bool> SendEmailAsync(Message message);

    }
}
