using Brainfinity.Domain.Models;
using Brainfinity.Domain.ServiceInterfaces;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brainfinity.Service.Services
{
    public class TeamValidationService : ITeamValidationService
    {
        private readonly IValidator<RegisterTeamModel> teamRegistrationValidator;

        public TeamValidationService(IValidator<RegisterTeamModel> teamRegistrationValidator)
        {
            this.teamRegistrationValidator = teamRegistrationValidator;
        }

        public void ValidateTeamRegistrationModel(RegisterTeamModel team)
        {
            var validationResult = teamRegistrationValidator.Validate(team);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }
        }
    }
}