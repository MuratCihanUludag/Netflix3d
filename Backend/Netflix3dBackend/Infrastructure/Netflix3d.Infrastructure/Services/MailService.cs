using Microsoft.Extensions.Configuration;
using Netflix3d.Application.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Netflix3d.Infrastructure.Services
{
    public class MailService : IMailService
    {
        private readonly IConfiguration _configuration;

        public MailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendMailAsync(string to, string subject, string body, bool isHtml = true)
        {
            await SendMailAsync(new[] { to }, subject, body, isHtml);
        }

        public async Task SendMailAsync(string[] tos, string subject, string body, bool isHtml = true)
        {
            MailMessage mail = new();
            mail.IsBodyHtml = isHtml;
            foreach (var to in tos)
                mail.To.Add(to);

            mail.Subject = subject;
            mail.Body = body;
            mail.From = new(_configuration["Mail:Epost"], "Netflix 3d Clone", Encoding.UTF8);

            SmtpClient smtpClient = new();
            smtpClient.Credentials = new NetworkCredential(_configuration["Mail:Epost"], _configuration["Mail:Password"]);
            smtpClient.Port = 587;
            smtpClient.EnableSsl = true;
            smtpClient.Host = _configuration["Mail:Host"];

            await smtpClient.SendMailAsync(mail);
        }
    }
}
