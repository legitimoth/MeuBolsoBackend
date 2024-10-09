namespace MeuBolso.Api.Interfaces.Repositories;

public interface IUnitOfWork
{
    public Task SaveAsync();
}
