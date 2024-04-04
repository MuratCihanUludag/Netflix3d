using Netflix3d.Application.Repositories;
using Netflix3d.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netflix3d.Application.Abstractions
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        public IReadRepository<T> GetReadRepository<T>() where T : BaseEntity, new();
        public IWriteRepository<T> GetWriteRepository<T>() where T : BaseEntity, new();
        Task<int> SaveAsync();
        int Save();

    }
}
