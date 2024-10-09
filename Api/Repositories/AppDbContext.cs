using MeuBolso.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace MeuBolso.Api.Repositories;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<UsuarioEntity> Usuarios { get; set; }
}