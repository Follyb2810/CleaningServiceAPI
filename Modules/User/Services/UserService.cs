// using CleaningServiceAPI.Modules.User.DTOs;
// using CleaningServiceAPI.Modules.User.Models;
// using CleaningServiceAPI.Modules.User.Repositories;
// using CleaningServiceAPI.Modules.User.DTOs;
// using CleaningServiceAPI.Modules.User.Models;

namespace CleaningServiceAPI.Modules.User.Services
{


    public class UserService
    {
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
        public object First()
        {
            return new { message = "User service works!" };
        }

    }
}