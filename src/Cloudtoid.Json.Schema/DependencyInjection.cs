namespace Cloudtoid.Json.Schema
{
    using System.Diagnostics;
    using Microsoft.Extensions.DependencyInjection;
    using static Contract;

    [DebuggerStepThrough]
    public static class DependencyInjection
    {
        public static IServiceCollection AddFramework(this IServiceCollection services)
        {
            CheckValue(services, nameof(services));

            if (services.Exists<Marker>())
                return services;

            return services
                .TryAddSingleton<Marker>();
        }

        private sealed class Marker
        {
        }
    }
}
