using Microsoft.Extensions.DependencyInjection;

namespace Api.Temporal.Setup;

public static class TemporalServiceCollectionExtensions
{
    public static IServiceCollection AddClock(this IServiceCollection services)
    {
        services.AddTransient<IClock, SystemClock>();
        return services;
    }
}
