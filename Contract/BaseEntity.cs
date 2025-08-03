using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleaningServiceAPI.Contract
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
    }
}
// public class UserModel : BaseEntity
// public class Repository<T> : IBaseRepository<T> where T : BaseEntity
// 
// public async Task UpdateAsync(T entity)
// {
//     var existingEntity = await FindByIdAsync(entity.Id);
//     if (existingEntity is null)
//     {
//         throw new KeyNotFoundException($"Entity with ID {entity.Id} was not found.");
//     }

//     _dbContext.Entry(existingEntity).CurrentValues.SetValues(entity);
//     await _dbContext.SaveChangesAsync();
// }
