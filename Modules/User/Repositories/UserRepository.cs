using CleaningServiceAPI.Data;
using CleaningServiceAPI.Modules.User.Models;
using CleaningServiceAPI.Contract;
using Microsoft.EntityFrameworkCore;

namespace CleaningServiceAPI.Modules.User.Repositories
{
    // public class UserRepository : IUserRepository<UserModel>
    public class UserRepository : Repository<UserModel>, IUserRepository

    // public class UserRepository : Repository<UserModel>
    {
        private readonly CleaningServiceDbContext _context;

        public UserRepository(CleaningServiceDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<UserModel?> GetByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}
