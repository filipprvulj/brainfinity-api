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
        public Task<Guid> CreateTeamAsync(TeamDto teamDto, string password);
    }
}