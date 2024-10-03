using MeuBolso.Api.Interfaces.Repositories;
using MeuBolso.Api.Interfaces.Services;
using MeuBolso.Api.Repositories;
using MeuBolso.Api.Services;

namespace MeuBolso.Api.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<IUsuarioService, UsuarioService>();

        return services;
    }

    public static IServiceCollection RegisterRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IUsuarioRepository, UsuarioRepository>();

        return services;
    }
}
