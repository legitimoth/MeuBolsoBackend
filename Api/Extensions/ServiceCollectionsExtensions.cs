using MeuBolso.Api.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace MeuBolso.Api.Extensions;

public static class ServiceCollectionsExtensions
{
    public static IServiceCollection AddCustomServices(this IServiceCollection services, IConfiguration configuration)
    {
        DbContext(services, configuration);
        Auth(services, configuration);

        // Outros serviços
        services.AddControllers();
        services.AddOpenApi();

        return services;
    }

    private static void Auth(IServiceCollection services, IConfiguration configuration)
    {
        // Configuração da Autenticação JWT
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>
        {
            options.Authority = configuration["Auth0:Domain"];
            options.Audience = configuration["Auth0:Audience"];
            options.TokenValidationParameters = new TokenValidationParameters
            {
                // Configurações adicionais, se necessário
            };
        });
    }

    private static void DbContext(IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ContextDB>(options =>
                    options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
    }
}
