using CleaningServiceAPI.Modules.User.Models;
using CleaningServiceAPI.Modules.User.Repositories;
using Microsoft.EntityFrameworkCore;
using CleaningServiceAPI.Modules.User.DTOs;
using CleaningServiceAPI.Modules.User.Mappers;

namespace CleaningServiceAPI.Modules.User.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;
        // private readonly UserRepository _userRepository;

        // public UserService(UserRepository userRepository)
        // {
        //     _userRepository = userRepository;
        // }

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task UpdateUserAsync(int id, UserModel updatedUser)
        {
            await _userRepository.UpdateAsync(id, updatedUser);
            //      var user = await _repo.FindByIdAsync(id);
            // if (user is null) return null;

            // UserMapper.MapUpdate(dto, user);
            // await _repo.UpdateAsync(id, user);

            // return UserMapper.ToDto(user);
        }

        public async Task<UserModel?> FindByEmail(string email)
        {
            return await _userRepository.GetByEmailAsync(email);
        }
        public async Task<UserModel?> GetUserByEmailAsync(string email)
        {
            return await _userRepository.GetByEmailAsync(email);
            //  var user = await _repo.GetByEmailAsync(email);
            // return user == null ? null : UserMapper.ToDto(user);
        }

        public async Task CreateUserAsync(UserModel user)
        {
            await _userRepository.CreateAsync(user);
            //     var hashedPassword = BCrypt.Net.BCrypt.HashPassword(dto.Password);
            // var user = UserMapper.ToModel(dto, hashedPassword);
            // await _repo.CreateAsync(user);

            // return UserMapper.ToDto(user);
        }

        public async Task<IEnumerable<UserModel>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllAsync();
            //     var users = await _repo.GetAllAsync();
            // return UserMapper.ToDtoList(users);
        }
    }
}



// namespace CleaningServiceAPI.Modules.User.Services
// {


//     public class UserService
//     {
// private readonly UserRepository _repo;
// public UserService(UserRepository repo) => _repo = repo;

// public async Task<UserDto?> GetUserByEmail(string email)
// {
//     var user = await _repo.GetByEmailAsync(email);
//     if (user == null) return null;
//     return new DTOs.UserDto
//     {
//         FullName = user.FullName,
//         Email = user.Email,
//         Role = user.Role.ToString()
//     };
// }

// public async Task Create(User user)
// {
//     // hash password etc. here
//     await _repo.AddAsync(user);
// }
//         public object First()
//         {
//             return new { message = "User service works!" };
//         }

//     }
// }