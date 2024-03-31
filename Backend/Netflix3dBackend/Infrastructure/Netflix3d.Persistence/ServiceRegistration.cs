using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Netflix3d.Application.Repositories;
using Netflix3d.Domain.Entities.Identity;
using Netflix3d.Persistence.Context;
using Netflix3d.Persistence.Repositories.AppRoleRepository;
using Netflix3d.Persistence.Repositories.AppUserRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Netflix3d.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceService(this IServiceCollection services)
        {
            services.AddDbContext<NetflixDbContext>(opt => opt.UseSqlServer(Configuration.ConnectionString));
            services.AddScoped<IReadRepository<AppUser>, AppUserReadRepository>();
            services.AddScoped<IWriteRepositry<AppUser>, AppUserWriteRepository>();

            services.AddScoped<IReadRepository<AppRole>, AppRoleReadRepository>();
            services.AddScoped<IWriteRepositry<AppRole>, AppRoleWriteRepository>();

        }
    }
}
