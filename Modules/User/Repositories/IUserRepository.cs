using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleaningServiceAPI.Contract;
using CleaningServiceAPI.Modules.User.Models;

namespace CleaningServiceAPI.Modules.User.Repositories
{
    public interface IUserRepository : IBaseRepository<UserModel>
    {
        Task<UserModel?> GetByEmailAsync(string email);

    }
}