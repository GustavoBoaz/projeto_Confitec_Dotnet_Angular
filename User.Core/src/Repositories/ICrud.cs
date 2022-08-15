using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace User.Core.src.Repositories
{
    public interface ICrud<T>
    {
        Task CreateAsync(T entity);
        Task<T> ReadAsync(string id);
        Task UpdateAsync(T entity);
        Task DeleteAsync(string id);
        Task<List<T>> ListAsync();
    }
}