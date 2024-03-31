using Microsoft.EntityFrameworkCore;
using Netflix3d.Application.Repositories;
using Netflix3d.Domain.Entities.Identity;
using Netflix3d.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Netflix3d.Persistence.Repositories.AppRoleRepository
{
    public class AppRoleReadRepository : ReadRepository<AppRole>, IAppRoleReadRepository
    {
        public AppRoleReadRepository(NetflixDbContext context) : base(context)
        {
        }

    }
}
