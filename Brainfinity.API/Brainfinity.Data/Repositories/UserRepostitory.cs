using Brainfinity.Data.Entities;
using Brainfinity.Domain.RepositoryInterfaces;
using Brainfinity.Domain.Resources;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brainfinity.Data.Repositories
{
    public class UserRepostitory : IUserRepository
    {
        private readonly UserManager<User> userManager;

        public UserRepostitory(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<bool> IsTeamEmailUniqueAsync(string email)
        {
            var teams = await userManager.GetUsersInRoleAsync(RoleNames.Tim);
            return !teams.Any(t => t.Email == email);
        }

        public async Task<bool> IsTeamNameUniqueAsync(string teamName)
        {
            var teams = await userManager.GetUsersInRoleAsync(RoleNames.Tim);
            return !teams.Any(t => t.TeamName == teamName);
        }

        public async Task<bool> IsTeamUsernameUniqueAsync(string username)
        {
            var teams = await userManager.GetUsersInRoleAsync(RoleNames.Tim);
            return !teams.Any(t => t.UserName == username);
        }
    }
}