using Brainfinity.Domain.RepositoryInterfaces;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brainfinity.Domain.ValidatorExtensions
{
    public static class TeamValidatorExtensions
    {
        public static IRuleBuilderOptions<T, TProperty> ValidPassword<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder)
        {
            return ruleBuilder.Must(password => IsPasswordValid(password.ToString()))
                .WithMessage("Lozinka mora imati najmanje jedan broj, specijalan karakter, veliko i malo slovo.");
        }

        public static IRuleBuilderOptions<T, TProperty> ValidName<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder)
        {
            return ruleBuilder.Must(name => IsValidName(name.ToString()))
                .WithMessage("Ime i prezime mogu sadržati samo slova.");
        }

        public static IRuleBuilderOptions<T, TProperty> UniqueEmail<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder, IUserRepository userRepository)
        {
            return ruleBuilder.MustAsync(async (email, cancellation) => await userRepository.IsTeamEmailUniqueAsync(email.ToString()))
                .WithMessage("Email adresa mora biti jedinstvena.");
        }

        public static IRuleBuilderOptions<T, TProperty> UniqueTeamName<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder, IUserRepository userRepository)
        {
            return ruleBuilder.MustAsync(async (teamName, cancellation) => await userRepository.IsTeamNameUniqueAsync(teamName.ToString()))
                .WithMessage("Naziv tima mora biti jedinstven.");
        }

        public static IRuleBuilderOptions<T, TProperty> UniqueTeamUsername<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder, IUserRepository userRepository)
        {
            return ruleBuilder.MustAsync(async (username, cancellation) => await userRepository.IsTeamUsernameUniqueAsync(username.ToString()))
                .WithMessage("Korisničko ime tima mora biti jedinstveno.");
        }

        private static bool IsPasswordValid(string password)
        {
            return password.Any(char.IsUpper)
                && password.Any(char.IsLower)
                && password.Any(char.IsNumber)
                && password.Any(ch => !char.IsLetterOrDigit(ch) && !char.IsWhiteSpace(ch));
        }

        private static bool IsValidName(string name)
        {
            return name.All(ch => char.IsWhiteSpace(ch) || char.IsLetter(ch));
        }
    }
}