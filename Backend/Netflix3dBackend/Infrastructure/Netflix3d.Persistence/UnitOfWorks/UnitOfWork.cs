using Netflix3d.Application.Abstractions;
using Netflix3d.Application.Repositories;
using Netflix3d.Domain.Entities.Common;
using Netflix3d.Persistence.Context;
using Netflix3d.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netflix3d.Persistence.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly NetflixDbContext _context;

        public UnitOfWork(NetflixDbContext context)
        {
            _context = context;
        }
        public async ValueTask DisposeAsync() => await _context.DisposeAsync();
        public int Save() => _context.SaveChanges();


        public Task<int> SaveAsync() => _context.SaveChangesAsync();

        public IReadRepository<T> GetReadRepository<T>() where T : BaseEntity, new() => new ReadRepository<T>(_context);

        public IWriteRepository<T> GetWriteRepository<T>() where T : BaseEntity, new() => new WriteRepository<T>(_context);


    }
}
