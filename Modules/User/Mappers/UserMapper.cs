using CleaningServiceAPI.Modules.User.Models;
using CleaningServiceAPI.Modules.User.DTOs;


namespace CleaningServiceAPI.Modules.User.Mappers
{

    public static class UserMapper
    {
        public static UserDto ToDto(UserModel user)
        {
            return new UserDto
            {
                Id = user.Id,
                FullName = user.FullName,
                Email = user.Email,
                // Role = user.Role
            };
        }

        public static UserModel ToModel(CreateUserDto dto, string passwordHash)
        {
            return new UserModel
            {
                FullName = dto.FullName,
                Email = dto.Email,
                PasswordHash = passwordHash,
                // Role = UserRole.Client
            };
        }
        public static List<UserDto> ToDtoList(IEnumerable<UserModel> users)
        {
            return users.Select(ToDto).ToList();
        }
        public static void MapUpdate(UpdateUserDto dto, UserModel user)
        {
            user.FullName = dto.FullName;
            // user.Role = dto.Role;
        }
    }


    // public static class UserMapper
    // {
    //     // public static UserDto ToDto(object entity)
    //     // {
    //     //     return new UserDto
    //     //     {
    //     //         FullName = user.FullName,
    //     //         Email = user.Email,
    //     //         Role = user.Role.ToString()
    //     //     };
    //     // }
    //     // public static object ToDtos(object entity)
    //     // {
    //     //     return new UserDto
    //     //     {
    //     //         FullName = user.FullName,
    //     //         Email = user.Email,
    //     //         Role = user.Role.ToString()
    //     //     };
    //     // }
    // }

}