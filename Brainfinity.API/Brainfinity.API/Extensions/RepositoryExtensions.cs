using Brainfinity.Data.Repositories;
using Brainfinity.Domain.RepositoryInterfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brainfinity.API.Extensions
{
    public static class RepositoryExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ICompetitionRepository, CompetitionRepository>();
            services.AddScoped<IAuthRepository, AuthRepostiory>();

            return services;
        }
    }
}