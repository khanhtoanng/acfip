﻿using ACFIP.Data.Helpers;
using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ACFIP.Bussiness.Services.EmailSender
{
    public class EmailSenderService : IEmailSenderService
    {
        private readonly EmailConfiguration _emailConfig;
        public EmailSenderService(EmailConfiguration emailConfig)
        {
            _emailConfig = emailConfig;
        }
        public async Task<bool> SendEmailAsync(Message message)
        {
            var mailMessage = CreateEmailMessage(message);
           return await SendAsync(mailMessage);
        }

        private MimeMessage CreateEmailMessage(Message message)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress(_emailConfig.From));
            emailMessage.To.AddRange(message.To);
            emailMessage.Subject = message.Subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = string.Format("<h2 style='color:red;'>{0}</h2>", message.Content) };
            return emailMessage;
        }
        private async Task<bool> SendAsync(MimeMessage mailMessage)
        {
            using (var client = new SmtpClient())
            {
                try
                {
                    await client.ConnectAsync(_emailConfig.SmtpServer, _emailConfig.Port, true);
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    await client.AuthenticateAsync(_emailConfig.UserName, _emailConfig.Password);
                    await client.SendAsync(mailMessage);
                }
                catch
                {
                    throw new Exception("Send Email Fails!");
                }
                finally
                {
                    await client.DisconnectAsync(true);
                    client.Dispose();
                }
            }
            return true;
        }
    }
}