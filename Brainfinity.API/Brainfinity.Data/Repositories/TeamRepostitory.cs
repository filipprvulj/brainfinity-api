using AutoMapper;
using Brainfinity.Data.Entities;
using Brainfinity.Data.Extensions;
using Brainfinity.Domain.Dtos;
using Brainfinity.Domain.Models;
using Brainfinity.Domain.Pagination;
using Brainfinity.Domain.RepositoryInterfaces;
using Brainfinity.Domain.Resources;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brainfinity.Data.Repositories
{
    public class TeamRepostitory : ITeamRepository
    {
        private readonly UserManager<User> userManager;
        private readonly IMapper mapper;
        private readonly ApplicationDbContext context;

        public TeamRepostitory(UserManager<User> userManager, IMapper mapper, ApplicationDbContext context)
        {
            this.userManager = userManager;
            this.mapper = mapper;
            this.context = context;
        }

        public PaginatorOutput<TeamOutputModel> CreatePaginatedTeams(PaginatorInput paginator, List<TeamOutputModel> teams, int totalTeams)
        {
            int teamsCount = teams.Count;
            if (teamsCount < paginator.Size)
            {
                paginator.Size = teamsCount;
            }

            PaginatorMetadata metadata = new PaginatorMetadata(totalTeams, paginator.Page, paginator.Size);
            return new PaginatorOutput<TeamOutputModel>(teams, metadata);
        }

        public async Task<TeamDto> GetTeamById(Guid id)
        {
            return mapper.Map<TeamDto>(await userManager.FindByIdAsync(id.ToString()));
        }

        public async Task<int> TeamCompetitionApply(Guid teamId, Guid competitionId)
        {
            var teamEntity = await userManager.Users.Include(u => u.Competitions).FirstOrDefaultAsync(u => u.Id == teamId);

            teamEntity.Competitions = new List<Competition>() { context.Competitions.FirstOrDefault(c => c.Id == competitionId) };

            context.Update(teamEntity);
            return await context.SaveChangesAsync();
        }

        public async Task<PaginatorOutput<TeamOutputModel>> GetTeamsAsync(PaginatorInput paginator)
        {
            var teams = await userManager.GetUsersInRoleAsync(RoleNames.Tim);
            var t = userManager.Users.Where(u => teams.Contains(u)).Include(u => u.Grade).Include(u => u.TeamMentor);
            var teamsOutput = await mapper.ProjectTo<TeamOutputModel>(t.Paginate(paginator)).ToListAsync();
            return CreatePaginatedTeams(paginator, teamsOutput, teams.Count);
        }

        public async Task<bool> IsTeamEmailUniqueAsync(string email)
        {
            var teams = await userManager.GetUsersInRoleAsync(RoleNames.Tim);
            return !teams.Any(t => t.Email == email);
        }

        public async Task<bool> IsTeamNameUniqueAsync(string teamName)
        {
            var teams = await userManager.GetUsersInRoleAsync(RoleNames.Tim);
            return !teams.Any(t => t.TeamName == teamName);
        }

        public async Task<bool> IsTeamUsernameUniqueAsync(string username)
        {
            var teams = await userManager.GetUsersInRoleAsync(RoleNames.Tim);
            return !teams.Any(t => t.UserName == username);
        }
    }
}