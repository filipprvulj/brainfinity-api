using AutoMapper;
using Brainfinity.Data.Entities;
using Brainfinity.Domain.Dtos;
using Brainfinity.Domain.RepositoryInterfaces;
using Brainfinity.Domain.Resources;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Brainfinity.Data.Repositories
{
    public class AuthRepostiory : IAuthRepository
    {
        private readonly IMapper mapper;
        private readonly UserManager<User> userManager;

        public AuthRepostiory(IMapper mapper, UserManager<User> userManager)
        {
            this.mapper = mapper;
            this.userManager = userManager;
        }

        public async Task<bool> CheckPasswordAsync(UserDto userDto, string password)
        {
            var user = await userManager.FindByIdAsync(userDto.Id.ToString());
            return await userManager.CheckPasswordAsync(user, password);
        }

        public async Task<Guid> CreateTeamAsync(TeamDto teamDto, string password)
        {
            var team = mapper.Map<User>(teamDto);
            try
            {
                using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    var identityResult = await userManager.CreateAsync(team, password);
                    if (identityResult.Succeeded)
                    {
                        await userManager.AddToRoleAsync(team, RoleNames.Tim);
                    }

                    scope.Complete();
                }
            }
            catch (TransactionAbortedException ex)
            {
                throw new TransactionAbortedException(ex.Message);
            }

            return team.Id;
        }

        public async Task<UserDto> GetUserByEmailAsync(string email)
        {
            return mapper.Map<UserDto>(await userManager.FindByEmailAsync(email));
        }

        public Task<IList<string>> GetUserRolesAsync(UserDto userDto)
        {
            User user = mapper.Map<User>(userDto);
            return userManager.GetRolesAsync(user);
        }
    }
}