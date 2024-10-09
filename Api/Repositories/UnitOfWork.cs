using MeuBolso.Api.Interfaces.Repositories;

namespace MeuBolso.Api.Repositories;

public class UnitOfWork(AppDbContext context) : IUnitOfWork
{
    private readonly AppDbContext _context = context;

    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }
}
