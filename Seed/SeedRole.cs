using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleaningServiceAPI.Modules.User.Models;
using Microsoft.AspNetCore.Identity;


namespace CleaningServiceAPI.Seed
{
    public static class RoleSeeder
    {
        public static async Task SeedRolesAsync(RoleManager<IdentityRole> roleManager)
        {
            foreach (UserRole role in Enum.GetValues(typeof(UserRole)))
            {
                var roleName = Enum.GetName(typeof(UserRole), role);
                if (!string.IsNullOrEmpty(roleName) && !await roleManager.RoleExistsAsync(roleName))
                {
                    await roleManager.CreateAsync(new IdentityRole(roleName));
                }

            }
        }
    }

}