using Brainfinity.Domain.Dtos;
using Brainfinity.Domain.Models;
using Brainfinity.Domain.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brainfinity.Domain.RepositoryInterfaces
{
    public interface ITeamRepository
    {
        public Task<TeamDto> GetTeamById(Guid id);

        public Task<int> TeamCompetitionApply(Guid teamId, Guid competitionId);

        public Task<PaginatorOutput<TeamOutputModel>> GetTeamsAsync(PaginatorInput paginator);

        public PaginatorOutput<TeamOutputModel> CreatePaginatedTeams(PaginatorInput paginator, List<TeamOutputModel> teams, int totalTeams);

        public Task<bool> IsTeamEmailUniqueAsync(string email);

        public Task<bool> IsTeamNameUniqueAsync(string teamName);

        public Task<bool> IsTeamUsernameUniqueAsync(string username);
    }
}