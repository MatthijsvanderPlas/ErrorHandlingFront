using System.Reflection;
using ErrorHandlingFront.Application.Common.Pipelines;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace ErrorHandlingFront.Application.Common.Composers;

public static class RegisterDependencies
{
    public static IServiceCollection AddApplicationFront(this IServiceCollection services)
    {
        services.AddMediatR(options =>
        {
            options.Lifetime = ServiceLifetime.Scoped;
            options.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            options.AddBehavior(typeof(IPipelineBehavior<,>),
                typeof(NotificationPipelineBehavior<,>));
        });
        
        return services;
    }
}