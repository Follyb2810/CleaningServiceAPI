using CleaningServiceAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace CleaningServiceAPI.Contract
{
    public class Repository<T> : IBaseRepository<T> where T : class
    {
        private readonly CleaningServiceDbContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public Repository(CleaningServiceDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T?> FindByIdAsync(string id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task CreateAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(string id, T entity)
        {
            var existingEntity = await FindByIdAsync(id);
            if (existingEntity is null)
                throw new KeyNotFoundException($"Entity with ID {id} not found.");

            _dbContext.Entry(existingEntity).CurrentValues.SetValues(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var entity = await FindByIdAsync(id);
            if (entity is null)
                throw new KeyNotFoundException($"Entity with ID {id} not found.");

            _dbSet.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}


