using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Netflix3d.Application.Repositories;
using Netflix3d.Domain.Entities.Common;
using Netflix3d.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netflix3d.Persistence.Repositories
{
    public class WriteRepositry<T> : IWriteRepositry<T> where T : BaseEntity
    {
        private readonly NetflixDbContext _context;
        public WriteRepositry(NetflixDbContext context)
        {
            _context = context;
        }
        public DbSet<T> Table => _context.Set<T>();

        public async Task<bool> AddAsync(T data)
        {
            data.Id = Guid.NewGuid();
            data.DataStatus = DataStatus.Insert;
            data.Created = DateTime.Now;
            EntityEntry<T> entity = await Table.AddAsync(data);
            await _context.SaveChangesAsync();
            return entity.State == EntityState.Added;
        }

        public async Task<bool> AddRangeAsync(List<T> datas)
        {
            foreach (var data in datas)
            {
                data.Id = Guid.NewGuid();
                data.DataStatus = DataStatus.Insert;
                data.Created = DateTime.Now;
            }
            await Table.AddRangeAsync(datas);
            return true;
        }
        public async Task<bool> RemoveAsync(string id)
        {
            T entity = await Table.FindAsync(Guid.Parse(id));
            EntityEntry<T> entityEntry = Table.Remove(entity);
            return entityEntry.State == EntityState.Deleted;
        }

        public bool Delete(T data)
        {
            data.DataStatus = DataStatus.Delete;
            data.Deleted = DateTime.Now;
            return Update(data);
        }
        public bool Update(T data)
        {
            if (data.DataStatus != DataStatus.Delete)
            {
                data.DataStatus = DataStatus.Update;
                data.Updated = DateTime.Now;
            }
            EntityEntry<T> entityEntry = Table.Update(data);
            return entityEntry.State == EntityState.Modified;
        }

        public async Task<int> SaveAsync() => await _context.SaveChangesAsync();
    }
}
