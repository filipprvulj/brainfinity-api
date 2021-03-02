using Brainfinity.Domain.Dtos;
using Brainfinity.Domain.Models;
using Brainfinity.Domain.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brainfinity.Domain.ServiceInterfaces
{
    public interface ITeamService
    {
        public Task<int> TeamCompetitionApply(Guid teamId, Guid competitionId);

        public Task<PaginatorOutput<TeamOutputModel>> GetTeamsAsync(PaginatorInput paginator);
    }
}