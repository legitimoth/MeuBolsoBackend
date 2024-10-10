namespace MeuBolsoBackend;

public class UnitOfWork(AppDbContext context) : IUnitOfWork
{
    private readonly AppDbContext _context = context;

    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }
}
