using Microsoft.Extensions.Configuration;
using Netflix3d.Application.Abstractions;
using Netflix3d.Domain.Entities.Identity;
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
        public async Task EmailVerifier(AppUser user)
        {
            StringBuilder mail = new();
            mail.Append(@$"Merhaba <b>{user.Name} {user.Surname}</b> <br>");
            mail.AppendLine("Hesabınızı oluşturduğunuz için teşekkür ederiz! Uygulamamızı kullanmaya başlamak için son bir adım kaldı.<br>");
            mail.AppendLine("Hesabınızın tam olarak etkinleştirilmesi için lütfen aşağıdaki butona tıklayarak e-posta adresinizi onaylayın. Bu işlem sadece birkaç saniyenizi alacak ve uygulamamızı kullanmaya başlayabilmeniz için gereklidir.<br>");
            mail.AppendLine("<a href='https://www.google.com'>Onayla</a>");

            await SendMailAsync(user.Email, "Epost Onaylama", mail.ToString());
        }
    }
}
