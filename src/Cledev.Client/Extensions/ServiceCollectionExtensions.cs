using Cledev.Client.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace Cledev.Client.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCledevClient(this IServiceCollection services, string baseAddress, string httpClientName = "Cledev.ServerAPI")
    {
        if (services is null)
        {
            throw new ArgumentNullException(nameof(services));
        }

        services.AddHttpClient(httpClientName, client => client.BaseAddress = new Uri(baseAddress))
            .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

        // Supply HttpClient instances that include access tokens when making requests to the server project
        services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient(httpClientName));

        services.AddHttpClient<ApiServiceAnonymous>(client =>
        {
            client.BaseAddress = new Uri(baseAddress);
        });

        services.AddHttpClient<ApiServiceAuthenticated>(client =>
        {
            client.BaseAddress = new Uri(baseAddress);
        }).AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

        services.AddScoped<ApiService>();

        services.Scan(s => s
            .FromAssembliesOf(typeof(ServiceCollectionExtensions))
            .AddClasses()
            .AsImplementedInterfaces());

        return services;
    }
}