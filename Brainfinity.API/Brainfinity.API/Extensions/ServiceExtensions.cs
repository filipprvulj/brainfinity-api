﻿using Brainfinity.Domain.ServiceInterfaces;
using Brainfinity.Service.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brainfinity.API.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<ICompetitionService, CompetitionService>();

            return services;
        }
    }
}