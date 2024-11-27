using MessageHawk.Outbox.Application.Services;
using MessageHawk.Outbox.Domain.Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;

namespace MessageHawk.Outbox.Application.Configurations
{
    public static class DependencyInjectionConfiguration
    {
        public static IServiceCollection ServicesDependencies(this IServiceCollection services)
        {
            services.AddScoped<IEnvelopeService, EnvelopeService>();

            return services;
        }
    }
}
