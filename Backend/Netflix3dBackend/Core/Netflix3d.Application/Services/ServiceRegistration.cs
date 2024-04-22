using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Netflix3d.Application.Beheviors;
using Netflix3d.Application.Expections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netflix3d.Application.Services
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(opt => opt.RegisterServicesFromAssemblies(typeof(ServiceRegistration).Assembly));

            services.AddTransient<ExpectionMiddelware>();

            services.AddValidatorsFromAssembly(typeof(ServiceRegistration).Assembly);

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(FluentValidationBehevior<,>));

        }
    }
}
