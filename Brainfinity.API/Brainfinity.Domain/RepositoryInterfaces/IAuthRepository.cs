using Brainfinity.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brainfinity.Domain.RepositoryInterfaces
{
    public interface IAuthRepository
    {
        public Task<UserDto> GetUserByEmailAsync(string email);

        public Task<bool> CheckPasswordAsync(UserDto userDto, string password);

        public Task<IList<string>> GetUserRolesAsync(UserDto userDto);

        public Task<Guid> CreateTeamAsync(TeamDto teamDto, string password);
    }
}