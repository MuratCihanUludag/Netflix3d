using Microsoft.EntityFrameworkCore;
using Netflix.Entity.Concrate;


namespace Netflix.DAL.Context.EF
{

    internal class NetflixDbContext : DbContext
    {
        public NetflixDbContext(DbContextOptions<NetflixDbContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
      
    }
}
