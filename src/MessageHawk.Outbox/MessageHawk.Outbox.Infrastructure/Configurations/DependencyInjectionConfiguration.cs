using MessageHawk.Outbox.Domain.Interfaces.Providers;
using MessageHawk.Outbox.Infrastructure.Providers;
using Microsoft.Extensions.DependencyInjection;

namespace MessageHawk.Outbox.Infrastructure.Configurations
{
    public static class DependencyInjectionConfiguration
    {
        public static IServiceCollection ProvidersDependencies(this IServiceCollection services)
        {
            services.AddScoped<IRabbitMqProvider, RabbitMqProvider>();

            return services;
        }
    }
}
