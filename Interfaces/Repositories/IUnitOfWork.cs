namespace MeuBolsoBackend;

public interface IUnitOfWork
{
    public Task SaveAsync();
}
