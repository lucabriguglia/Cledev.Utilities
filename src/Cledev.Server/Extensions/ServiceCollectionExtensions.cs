using Microsoft.Extensions.DependencyInjection;

namespace Cledev.Server.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCledevServer(this IServiceCollection services)
    {
        if (services is null)
        {
            throw new ArgumentNullException(nameof(services));
        }

        services.Scan(s => s
            .FromAssembliesOf(typeof(ServiceCollectionExtensions))
            .AddClasses()
            .AsImplementedInterfaces());

        return services;
    }
}