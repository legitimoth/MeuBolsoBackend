namespace MeuBolsoBackend;

public static class ServiceExtensions
{
    public static IServiceCollection RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<IUsuarioService, UsuarioService>();
        services.AddScoped<ITagService, TagService>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<ICartaoService, CartaoService>();
        services.AddScoped<IPagamentoService, PagamentoService>();

        return services;
    }

    public static IServiceCollection RegisterRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IUsuarioRepository, UsuarioRepository>();
        services.AddScoped<ITagRepository, TagRepository>();
        services.AddScoped<ICartaoRepository, CartaoRepository>();
        services.AddScoped<IPagamentoRepository, PagamentoRepository>();

        return services;
    }
}
