using Microsoft.Extensions.DependencyInjection;
using TodoApi.Application.Abstractions;
using TodoApi.Infrastructure.Auth;
using TodoApi.Infrastructure.Persistence;

namespace TodoApi.Infrastructure.DependencyInjection;

public static class InfrastructureServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<ITodoRepository, InMemoryTodoRepository>();
        services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
        return services;
    }
}
