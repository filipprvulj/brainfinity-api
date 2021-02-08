using Brainfinity.Domain.Models;
using Brainfinity.Domain.RepositoryInterfaces;
using Brainfinity.Domain.ValidatorExtensions;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brainfinity.Domain.Validators
{
    public class TeamRegistrationValidator : AbstractValidator<RegisterTeamModel>
    {
        public TeamRegistrationValidator(IUserRepository userRepository)
        {
            CascadeMode = CascadeMode.Stop;

            RuleFor(team => team.TeamName)
                .NotEmpty()
                .WithMessage("Ime tima ne može biti prazno.")
                .Length(2, 50)
                .WithMessage("Ime tima mora imati između 2 i 20 karaktera.")
                .UniqueTeamName(userRepository);

            RuleFor(team => team.Email)
                .NotEmpty()
                .WithMessage("Email adresa ne može biti prazna.")
                .EmailAddress()
                .WithMessage("'{PropertyValue}' nije validna email adresa.")
                .UniqueEmail(userRepository);

            RuleFor(team => team.UserName)
                .NotEmpty()
                .WithMessage("Korisničko ime ne može biti prazno.")
                .Length(2, 20)
                .WithMessage("Korisničko ime mora imati između 2 i 20 karaktera.")
                .UniqueTeamUsername(userRepository);

            RuleFor(team => team.Password)
                .NotEmpty()
                .WithMessage("Lozinka ne može biti prazna.")
                .MinimumLength(8)
                .WithMessage("Lozinka mora imati najmanje 8 karaktera.")
                .ValidPassword();

            RuleForEach(team => team.TeamMembers)
                .ChildRules(cr =>
                {
                    cr.CascadeMode = CascadeMode.Stop;
                    cr.RuleFor(teamMember => teamMember.FirstName)
                        .NotEmpty()
                        .WithMessage("Ime ne može biti prazno.")
                        .ValidName();

                    cr.RuleFor(teamMember => teamMember.LastName)
                        .NotEmpty()
                        .WithMessage("Prezime ne može biti prazno.")
                        .ValidName();
                });
        }
    }
}