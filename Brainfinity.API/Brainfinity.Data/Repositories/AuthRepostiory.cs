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

        public async Task<Guid> CreateTeamAsync(UserDto userDto, string password)
        {
            var user = mapper.Map<User>(userDto);
            try
            {
                using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    var identityResult = await userManager.CreateAsync(user, password);
                    if (identityResult.Succeeded)
                    {
                        await userManager.AddToRoleAsync(user, RoleNames.Tim);
                    }

                    scope.Complete();
                }
            }
            catch (TransactionAbortedException ex)
            {
                throw new TransactionAbortedException(ex.Message);
            }

            return user.Id;
        }
    }
}