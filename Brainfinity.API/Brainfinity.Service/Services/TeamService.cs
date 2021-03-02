using Brainfinity.Domain.Dtos;
using Brainfinity.Domain.Models;
using Brainfinity.Domain.Pagination;
using Brainfinity.Domain.RepositoryInterfaces;
using Brainfinity.Domain.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brainfinity.Service.Services
{
    public class TeamService : ITeamService
    {
        private readonly ITeamRepository teamRepository;

        public TeamService(ITeamRepository teamRepository)
        {
            this.teamRepository = teamRepository;
        }

        public Task<PaginatorOutput<TeamOutputModel>> GetTeamsAsync(PaginatorInput paginator)
        {
            return teamRepository.GetTeamsAsync(paginator);
        }

        public Task<int> TeamCompetitionApply(Guid teamId, Guid competitionId)
        {
            return teamRepository.TeamCompetitionApply(teamId, competitionId);
        }
    }
}