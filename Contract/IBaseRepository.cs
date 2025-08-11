using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleaningServiceAPI.Contract
{
    public interface IBaseRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> FindByIdAsync(string id);
        Task CreateAsync(T entity);
        Task UpdateAsync(string id, T entity);
        Task DeleteAsync(string id);
    }
}
