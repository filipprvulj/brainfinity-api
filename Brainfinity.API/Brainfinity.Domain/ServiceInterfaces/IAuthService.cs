using Brainfinity.Domain.Dtos;
using Brainfinity.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brainfinity.Domain.ServiceInterfaces
{
    public interface IAuthService
    {
        public Task<Guid> CreateTeamAsync(RegisterTeamModel team);

        public Task<string> LoginUserAsync(LoginUserModel loginUser);
    }
}