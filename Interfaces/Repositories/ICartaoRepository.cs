namespace MeuBolsoBackend;

public interface ICartaoRepository
{
    Task<CartaoEntity> AdicionarAsync(CartaoEntity cartaoEntity);
    void Atualizar(CartaoEntity cartaoEntity);
    Task<CartaoEntity?> RecuperarPorIdAsync(long id);
    Task<bool> ExistePorIdAsync(long id);
    Task<bool> ExistePorNomeEFinalEUsuarioIdAsync(string nome, string final, long usuarioId);
    Task RemoverPorIdAsync(long id);
    Task<List<CartaoEntity>> RecuperarTodosPorUsuarioIdAsync(long usuarioId);
}