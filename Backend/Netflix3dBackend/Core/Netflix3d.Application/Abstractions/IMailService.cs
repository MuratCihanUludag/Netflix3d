using Netflix3d.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netflix3d.Application.Abstractions
{
    public interface IMailService
    {
        Task SendMailAsync(string to, string subject, string body, bool isHtml = true);
        Task SendMailAsync(string[] to, string subject, string body, bool isHtml = true);
        Task EmailVerifier(AppUser user);
    }
}
