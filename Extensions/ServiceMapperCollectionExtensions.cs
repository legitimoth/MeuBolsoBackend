using AutoMapper;
using AutoMapper.EquivalencyExpression;

namespace MeuBolsoBackend;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddAutoMapperWithCollectionMappers(this IServiceCollection services)
    {
        services.AddAutoMapper((serviceProvider, mapperConfiguration) =>
        {
            mapperConfiguration.AddMaps(typeof(Program).Assembly);
            mapperConfiguration.AddCollectionMappers();
            mapperConfiguration.UseEntityFrameworkCoreModel<AppDbContext>(serviceProvider);
        }, typeof(Program).Assembly);

        return services;
    }
}