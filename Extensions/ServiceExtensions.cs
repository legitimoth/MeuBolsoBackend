using System.Reflection;

namespace MeuBolsoBackend;

public static class ServiceExtensions
{
    
    public static IServiceCollection RegisterServices(this IServiceCollection services)
    {
        RegisterServicesByConvention(services, "Service");
        return services;
    }

    public static IServiceCollection RegisterRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        RegisterServicesByConvention(services, "Repository");
        return services;
    }

    private static void RegisterServicesByConvention(IServiceCollection services, string suffix)
    {
        
        // Encontra todas as classes que terminam com o sufixo especificado e não são abstratas
        var implementations = Assembly.GetExecutingAssembly().GetTypes()
            .Where(type => type is { IsClass: true, IsAbstract: false } && type.Name.EndsWith(suffix))
            .ToList();

        foreach (var implementation in implementations)
        {
            // Encontra a interface correspondente que começa com 'I' seguido do nome da classe
            var interfaceName = $"I{implementation.Name}";
            var interfaceType = implementation.GetInterfaces()
                .FirstOrDefault(i => i.Name.Equals(interfaceName, StringComparison.InvariantCultureIgnoreCase));

            if (interfaceType != null)
            {
                // Registra o serviço com tempo de vida Scoped
                services.AddScoped(interfaceType, implementation);
            }
        }
    }
}
