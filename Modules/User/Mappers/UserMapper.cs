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
                Id = user.Id.ToString(), 
                FullName = user.FullName,
                Email = user.Email
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
                PhoneNumber = dto.PhoneNumber,
                Address = dto.Address,
                City = dto.City,
                PostalCode = dto.PostalCode,
                CreatedAt = DateTime.UtcNow
            };
        }

        public static List<UserDto> ToDtoList(IEnumerable<UserModel> users)
        {
            return users.Select(ToDto).ToList();
        }

        public static void MapUpdate(this UserModel user, UpdateUserDto dto)
        {
            user.FullName = dto.FullName;
            user.Email = dto.Email;
            user.PhoneNumber = dto.PhoneNumber;
            user.Address = dto.Address;
            user.City = dto.City;
            user.PostalCode = dto.PostalCode;
            user.UpdatedAt = DateTime.UtcNow;
        }
    }
}
