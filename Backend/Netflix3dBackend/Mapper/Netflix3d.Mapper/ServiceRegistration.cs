using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Netflix3d.Application.Abstractions;
using Netflix3d.Application.Abstractions.AutoMapper;
using Netflix3d.Application.Repositories;
using Netflix3d.Domain.Entities.Identity;
using Netflix3d.Mapper.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Netflix3d.Mapper
{
    public static class ServiceRegistration
    {
        public static void AddMapperService(this IServiceCollection services)
        {
            services.AddSingleton<IMapper, AutoMapper.Mapper>();

        }
    }
}
