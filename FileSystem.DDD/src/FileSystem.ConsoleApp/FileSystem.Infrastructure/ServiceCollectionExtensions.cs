using FileSystem.Infrastructure.Utilities;
using FileSystem.Infrastructure.Utilities.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace FileSystem.Infrastructure;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddServicesForInfrastructure(
        this IServiceCollection services)
    {
        if (services == null)
        {
            throw new ArgumentNullException(nameof(services));
        }

        services.AddTransient<IPathBuilder, PathBuilder>();

        return services;
    }
}