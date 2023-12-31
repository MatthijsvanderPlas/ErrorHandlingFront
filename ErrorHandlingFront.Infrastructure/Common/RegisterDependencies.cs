﻿using ErrorHandlingFront.Application.Interfaces;
using ErrorHandlingFront.Infrastructure.Persistence.Repositories;
using ErrorHandlingFront.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using Refit;

namespace ErrorHandlingFront.Infrastructure.Common;

public static class RegisterDependencies
{
    public static IServiceCollection AddInfrastructureFront(this IServiceCollection services)
    {
        services.AddScoped<ITodoService, TodoService>();
        
        services.AddRefitClient<ITodoRepository>()
            .ConfigureHttpClient(c => c.BaseAddress = new Uri("http://localhost:7071/api/todos"));
        return services;
    }
}