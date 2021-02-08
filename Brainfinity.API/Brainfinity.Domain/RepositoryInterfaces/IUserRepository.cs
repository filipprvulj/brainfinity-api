using Brainfinity.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brainfinity.Domain.RepositoryInterfaces
{
    public interface IUserRepository
    {
        public Task<bool> IsTeamEmailUniqueAsync(string email);

        public Task<bool> IsTeamNameUniqueAsync(string teamName);

        public Task<bool> IsTeamUsernameUniqueAsync(string username);
    }
}