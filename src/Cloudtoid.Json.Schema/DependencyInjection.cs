using System.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using static Cloudtoid.Contract;

namespace Cloudtoid.Json.Schema
{
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
