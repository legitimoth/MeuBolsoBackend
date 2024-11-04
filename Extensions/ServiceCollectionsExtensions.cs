using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using FluentValidation.AspNetCore;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace MeuBolsoBackend;

public static class ServiceCollectionsExtensions
{
    public static IServiceCollection AddCustomServices(this IServiceCollection services, IConfiguration configuration)
    {
        DbContext(services, configuration);
        Auth(services, configuration);
        Swagger(services, configuration);

        // Outros serviços
        services.RegisterServices();
        services.RegisterRepositories();
        services.AddAutoMapper(typeof(Program));
        services.AddFluentValidationAutoValidation();
        services.AddValidatorsFromAssembly(typeof(Program).Assembly);
        services.Configure<Auth0Settings>(configuration.GetSection("Auth0"));
        services.Configure<ApiBehaviorOptions>(options =>
        {
            options.SuppressModelStateInvalidFilter = true;
        });

        services.AddControllers(options =>
        {
            options.SuppressAsyncSuffixInActionNames = false;
            options.Filters.Add<ModelValidationFilter>();
            options.Filters.Add<ApiResponseFilter>();
        });

        services.AddOpenApi();

        return services;
    }

    private static void Swagger(IServiceCollection services, IConfiguration configuration)
    {
        // Configuração do Swagger
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Meu Bolso 💲", Version = "v1" });

            // Configuração do OAuth2 com Auth0
            var auth0Domain = configuration["Auth0:Domain"];
            var auth0ClientId = configuration["Auth0:Api:ClientId"];

            c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
            {
                Type = SecuritySchemeType.OAuth2,
                Description = "Auth0 OAuth2",
                Flows = new OpenApiOAuthFlows
                {
                    AuthorizationCode = new OpenApiOAuthFlow
                    {
                        AuthorizationUrl = new Uri($"{auth0Domain}/authorize"),
                        TokenUrl = new Uri($"{auth0Domain}/oauth/token"),
                    }
                }
            });

            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "oauth2"
                        }
                    },
                    new[] { "openid" }
                }
            });
        });

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
            options.Audience = configuration["Auth0:Api:Audience"];
        });
        services.AddHttpContextAccessor();
    }

    private static void DbContext(IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
                    options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
    }
}
