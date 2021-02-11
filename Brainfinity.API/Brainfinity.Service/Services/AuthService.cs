using AutoMapper;
using Brainfinity.Domain.Dtos;
using Brainfinity.Domain.Models;
using Brainfinity.Domain.RepositoryInterfaces;
using Brainfinity.Domain.ServiceInterfaces;
using Brainfinity.Service.ErrorHandling;
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
        private readonly ISecurityService securityService;

        public AuthService(IAuthRepository authRepository, ITeamValidationService teamValidationService, IMapper mapper, ISecurityService securityService)
        {
            this.authRepository = authRepository;
            this.teamValidationService = teamValidationService;
            this.mapper = mapper;
            this.securityService = securityService;
        }

        public async Task<Guid> CreateTeamAsync(RegisterTeamModel team)
        {
            teamValidationService.ValidateTeamRegistrationModel(team);

            var teamDto = mapper.Map<TeamDto>(team);
            teamDto.Logo = await team.Logo.ToByteArrayAsync();
            teamDto.TeamPicture = await team.Logo.ToByteArrayAsync();

            return await authRepository.CreateTeamAsync(teamDto, team.Password);
        }

        public async Task<string> LoginUserAsync(LoginUserModel loginUser)
        {
            var user = await authRepository.GetUserByEmailAsync(loginUser.Email);
            if (user == null)
            {
                ValidationException validationException = new ValidationException("Došlo je do greške.");
                validationException.Data.Add("email", "Pogrešna email adresa");
                throw validationException;
            }

            bool isPasswordValid = await authRepository.CheckPasswordAsync(user, loginUser.Password);
            if (!isPasswordValid)
            {
                ValidationException validationException = new ValidationException("Došlo je do greške.");
                validationException.Data.Add("lozinka", "Pogrešna lozinka");
                throw validationException;
            }

            var userRoles = await authRepository.GetUserRolesAsync(user);
            return securityService.GenerateJwtToken(user.Id, userRoles.FirstOrDefault());
        }
    }
}