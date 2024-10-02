using MeuBolso.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace MeuBolso.Api.Repositories;

public class ContextDB(DbContextOptions<ContextDB> options) : DbContext(options)
{
    public DbSet<UsuarioEntity> Usuarios { get; set; }
}