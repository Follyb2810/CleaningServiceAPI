using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleaningServiceAPI.Contract;
using CleaningServiceAPI.Modules.User.Models;
using CleaningServiceAPI.Modules.User.DTOs;

namespace CleaningServiceAPI.Modules.User.Repositories
{
    public interface IUserRepository : IBaseRepository<UserModel>
    {
        Task<UserModel?> GetByEmailAsync(string email);
        Task<UserModel?> GetUserByIdAsync(string id);
        Task<IEnumerable<UserModel>> GetAllUsersAsync();
        Task<UserModel> CreateUserAsync(CreateUserDto user, string hashedPassword); Task<UserModel?> UpdateUserAsync(string id, UpdateUserDto dto);



    }
}