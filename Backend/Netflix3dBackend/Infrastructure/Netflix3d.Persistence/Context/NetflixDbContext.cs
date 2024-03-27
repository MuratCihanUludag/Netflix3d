using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Netflix3d.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netflix3d.Persistence.Context
{
    public class NetflixDbContext : IdentityDbContext<NetflixUser, NetflixRole, string>
    {
        public NetflixDbContext(DbContextOptions<NetflixDbContext> options) : base(options)
        {

        }
    }
}
