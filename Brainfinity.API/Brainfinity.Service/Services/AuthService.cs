using Brainfinity.Domain.Dtos;
using Brainfinity.Domain.RepositoryInterfaces;
using Brainfinity.Domain.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brainfinity.Service.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository authRepository;

        public AuthService(IAuthRepository authRepository)
        {
            this.authRepository = authRepository;
        }

        public async Task<Guid> CreateTeamAsync(UserDto userDto, string password)
        {
            return await authRepository.CreateTeamAsync(userDto, password);
        }
    }
}