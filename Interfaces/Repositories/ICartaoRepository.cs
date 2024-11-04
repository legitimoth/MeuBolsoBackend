namespace MeuBolsoBackend;

public interface ICartaoRepository
{
    Task<CartaoEntity> AdicionarAsync(CartaoEntity cartaoEntity);
    void Atualizar(CartaoEntity cartaoEntity);
    Task<CartaoEntity?> RecuperarPorIdAsync(long id);
    Task<bool> ExistePorIdAsync(long id);
    Task<bool> ExistePorNomeEFinalAsync(string nome, string final);
    void RemoverAsync(CartaoEntity cartaoEntity);
    Task<List<CartaoEntity>> RecuperarTodosAsync();
}