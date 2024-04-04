using Netflix3d.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netflix3d.Application.Repositories
{
    public interface IWriteRepository<T> : IRepository<T> where T : BaseEntity
    {
        Task<bool> AddAsync(T data);
        Task<bool> AddRangeAsync(List<T> datas);
        bool Update(T data);
        bool Delete(T data);
        Task<bool> RemoveAsync(string id);
        Task<int> SaveAsync();

    }
}
