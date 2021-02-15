using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brainfinity.API.Extensions
{
    public static class CorsExtensions
    {
        public static IServiceCollection AddCustomCors(this IServiceCollection services, string policy, IConfiguration configuration)
        {
            CorsModel corsModel = configuration.GetSection("Cors").Get<CorsModel>();

            services.AddCors(options =>
            {
                options.AddPolicy(name: policy,
                    builder =>
                    {
                        builder.WithOrigins(corsModel.Origins)
                        .WithHeaders(corsModel.Headers)
                        .WithMethods(corsModel.Methods);
                    });
            });

            return services;
        }
    }
}