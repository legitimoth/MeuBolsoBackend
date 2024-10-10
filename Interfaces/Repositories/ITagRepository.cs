namespace MeuBolsoBackend;

public interface ITagRepository
{
    Task<TagEntity> AdicionarAsync(TagEntity tagEntity);
    void Atualizar(TagEntity tagEntity);
    Task<List<TagEntity>> RecuperarTodosPorUsuarioIdAsync(long usuarioId);
    Task<TagEntity?> RecuperarPorIdAsync(long id);
    Task<bool> ExistePorNomeEUsuarioIdAsync(string nome, long usuarioId);
    Task RemoverPorIdAsync(long id);
}
