using Brainfinity.Domain.Models;
using Brainfinity.Domain.Options;
using Brainfinity.Domain.RepositoryInterfaces;
using Brainfinity.Domain.ValidatorExtensions;
using FluentValidation;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brainfinity.Domain.Validators
{
    public class TeamRegistrationValidator : AbstractValidator<RegisterTeamModel>
    {
        public TeamRegistrationValidator(IUserRepository userRepository, IOptions<ImageOptions> imageOptions)
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

            RuleFor(team => team.TeamMentor)
                .ChildRules(cr =>
                {
                    cr.CascadeMode = CascadeMode.Stop;
                    cr.RuleFor(teamMentor => teamMentor.Email)
                        .NotEmpty()
                        .WithMessage("Email adresa mentora ne može biti prazna.")
                        .EmailAddress()
                        .WithMessage("'{PropertyValue}' nije validna email adresa.");

                    cr.RuleFor(teamMentor => teamMentor.FirstName)
                        .NotEmpty()
                        .WithMessage("Ime mentora ne može biti prazno.")
                        .ValidName();

                    cr.RuleFor(teamMentor => teamMentor.LastName)
                        .NotEmpty()
                        .WithMessage("Prezime mentora ne može biti prazno.")
                        .ValidName();
                });

            RuleFor(team => team.Logo)
                .NotEmpty()
                .WithMessage("Logo ne može biti prazan")
                .SetValidator(new FormFileValidator(imageOptions));

            RuleFor(team => team.TeamPicture)
                .NotEmpty()
                .WithMessage("Slika tima ne može biti prazna")
                .SetValidator(new FormFileValidator(imageOptions));
        }
    }
}