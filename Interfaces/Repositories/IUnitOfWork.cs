using Microsoft.EntityFrameworkCore.Storage;

namespace MeuBolsoBackend;

public interface IUnitOfWork
{
    public Task SaveAsync();
    public Task<IDbContextTransaction> BeginTransactionAsync();
}
