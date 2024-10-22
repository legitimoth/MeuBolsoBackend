using Microsoft.EntityFrameworkCore;

namespace MeuBolsoBackend;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<UsuarioEntity> Usuarios { get; set; }
    public DbSet<TagEntity> Tags { get; set; }
    public DbSet<CartaoEntity> Cartoes { get; set; }
    public DbSet<TipoPagamentoEntity> TiposPagamento { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}