using AutoMapper;
using Brainfinity.Domain.Dtos;
using Brainfinity.Domain.Models;
using Brainfinity.Domain.RepositoryInterfaces;
using Brainfinity.Domain.ServiceInterfaces;
using Brainfinity.Service.Extensions;
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
        private readonly ITeamValidationService teamValidationService;
        private readonly IMapper mapper;

        public AuthService(IAuthRepository authRepository, ITeamValidationService teamValidationService, IMapper mapper)
        {
            this.authRepository = authRepository;
            this.teamValidationService = teamValidationService;
            this.mapper = mapper;
        }

        public async Task<Guid> CreateTeamAsync(RegisterTeamModel team)
        {
            teamValidationService.ValidateTeamRegistrationModel(team);

            var teamDto = mapper.Map<TeamDto>(team);
            teamDto.Logo = await team.Logo.ToByteArrayAsync();
            teamDto.TeamPicture = await team.Logo.ToByteArrayAsync();

            return await authRepository.CreateTeamAsync(teamDto, team.Password);
        }
    }
}