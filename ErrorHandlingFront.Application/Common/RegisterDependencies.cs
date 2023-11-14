using Microsoft.Extensions.DependencyInjection;

namespace ErrorHandlingFront.Application.Common;

public static class RegisterDependencies
{
    public static IServiceCollection AddApplicationFront(this IServiceCollection services)
    {
        services.AddMediator(options =>
        {
            options.ServiceLifetime = ServiceLifetime.Scoped;
        });
        return services;
    }
}