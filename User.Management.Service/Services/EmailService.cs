﻿//In the EmailService, we’ll add a method to generate a random OTP.
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;
using User.Management.Service.Models;


namespace User.Management.Service.Services
{

    public class SmtpSettings
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool EnableSSL { get; set; }
    }
    public class EmailService : IEmailService
    {
        private readonly SmtpSettings _smtpSettings;

        public EmailService(IOptions<SmtpSettings> smtpSettings)
        {
            _smtpSettings = smtpSettings.Value;
        }

        public async Task SendOtpEmailAsync(EmailData emailData)
        {
            using (var client = new SmtpClient(_smtpSettings.Host, _smtpSettings.Port))
            {
                client.Credentials = new NetworkCredential(_smtpSettings.UserName, _smtpSettings.Password);
                client.EnableSsl = true;

                var mailMessage = new MailMessage
                {
                    From = new MailAddress(_smtpSettings.UserName),
                    Subject = emailData.Subject,
                    Body = emailData.Body,
                    IsBodyHtml = true
                };

                mailMessage.To.Add(emailData.To);

                await client.SendMailAsync(mailMessage);
            }
        }
    }
}
