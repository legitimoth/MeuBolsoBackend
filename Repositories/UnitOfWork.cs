using Microsoft.EntityFrameworkCore.Storage;

namespace MeuBolsoBackend;

public class UnitOfWork(AppDbContext context) : IUnitOfWork
{
    public async Task SaveAsync()
    {
        await context.SaveChangesAsync();
    }

    public async Task<IDbContextTransaction> BeginTransactionAsync()
    {
        return await context.Database.BeginTransactionAsync();
    }
}
