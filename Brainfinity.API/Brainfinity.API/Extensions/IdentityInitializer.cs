using AutoMapper.Configuration;
using Brainfinity.Data.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brainfinity.API.Extensions
{
    public static class IdentityInitializer
    {


        public static void UseSeedData(this IApplicationBuilder app, UserManager<User> userManager, RoleManager<IdentityRole<Guid>> roleManager)
        {
            Task.WaitAll(SeedRolesAsync(roleManager),
                SeedUsersAsync(userManager));
        }
        private async static Task SeedRolesAsync(RoleManager<IdentityRole<Guid>> roleManager)
        {
            var roleNames = new[] { "Supervizor", "Pregledač", "Žiri" };
            foreach (var roleName in roleNames)
            {
                await CreateRole(roleManager, roleName);

            }
        }
        private async static Task CreateRole(RoleManager<IdentityRole<Guid>> roleManager, string roleName)
        {
            if (!await roleManager.RoleExistsAsync(roleName))
            {
                IdentityRole<Guid> role = new IdentityRole<Guid>() { Name = roleName };

                await roleManager.CreateAsync(role);
            }

        }

        private async static Task SeedUsersAsync(UserManager<User> userManager)
        {
            var adminUsers = await userManager.GetUsersInRoleAsync("Supervizor");

            if (!adminUsers.Any())
            {
                User user = new User() { UserName = "Supervizor1", Email = "supervizor1@gmail.com" };
                var result = await userManager.CreateAsync(user, "Password1!");

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "Supervizor");
                }
            }
        }
    }
}
