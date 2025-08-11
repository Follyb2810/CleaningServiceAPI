using CleaningServiceAPI.Data;
using CleaningServiceAPI.Modules.User.Models;
using CleaningServiceAPI.Modules.User.DTOs;
using CleaningServiceAPI.Contract;
using Microsoft.EntityFrameworkCore;
using CleaningServiceAPI.Modules.User.Mappers;

namespace CleaningServiceAPI.Modules.User.Repositories
{
    public class UserRepository : Repository<UserModel>, IUserRepository
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

        public async Task<UserModel?> GetUserByIdAsync(string id)
        {
            return await _context.Users
                .Include(u => u.Subscriptions)
                    .ThenInclude(s => s.SubscriptionPlan)
                .Include(u => u.Bookings)
                .FirstOrDefaultAsync(u => u.Id == id.ToString());
        }

        public async Task<UserModel> CreateUserAsync(CreateUserDto dto, string hashedPassword)
        {
            var existing = await GetByEmailAsync(dto.Email);
            if (existing is not null)
                throw new InvalidOperationException("User with this email already exists.");

            var newUser = UserMapper.ToModel(dto, hashedPassword);
            await CreateAsync(newUser);
            return newUser;
        }

        public async Task<IEnumerable<UserModel>> GetAllUsersAsync()
        {
            return await _context.Users
                .Include(u => u.Subscriptions)
                .Include(u => u.Bookings)
                .ToListAsync();
        }

        public async Task<UserModel?> UpdateUserAsync(string id, UpdateUserDto dto)
        {
            var user = await FindByIdAsync(id);
            if (user is null)
                throw new KeyNotFoundException($"User with ID {id} not found.");

            user.MapUpdate(dto);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task DeleteUserAsync(string id)
        {
            await DeleteAsync(id);
        }
    }
}
