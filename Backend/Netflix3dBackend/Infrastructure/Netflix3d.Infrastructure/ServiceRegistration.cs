using Microsoft.Extensions.DependencyInjection;
using Netflix3d.Application.Abstractions;
using Netflix3d.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netflix3d.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IMailService, MailService>();
        }
    }
}
