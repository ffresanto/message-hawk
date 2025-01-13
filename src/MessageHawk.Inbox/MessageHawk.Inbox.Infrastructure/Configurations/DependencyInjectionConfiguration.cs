﻿using MessageHawk.Inbox.Domain.Interfaces.Repositories;
using MessageHawk.Inbox.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace MessageHawk.Inbox.Infrastructure.Configurations
{
    public static class DependencyInjectionConfiguration
    {
        public static IServiceCollection RepositoriesDependencies(this IServiceCollection services)
        {
            services.AddScoped<IEnvelopeRepository, EnvelopeRepository>();

            return services;
        }
    }
}