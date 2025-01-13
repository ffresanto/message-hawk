using MessageHawk.Inbox.Application.Services;
using MessageHawk.Inbox.Domain.Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;

namespace MessageHawk.Inbox.Application.Configurations
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
