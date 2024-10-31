namespace MeuBolsoBackend;

public interface ITagRepository
{
    Task<TagEntity> AdicionarAsync(TagEntity tagEntity);
    Task<List<TagEntity>> AdicionarAsync(List<TagEntity> tagsEntity);
    void Atualizar(TagEntity tagEntity);
    Task<List<TagEntity>> RecuperarTodosPorUsuarioIdAsync(long usuarioId);
    Task<TagEntity?> RecuperarPorIdAsync(long id);
    Task<List<TagEntity>> RecuperarPorIdAsync(List<long> ids);
    Task<bool> ExistePorNomeEUsuarioIdAsync(string nome, long usuarioId);
    Task RemoverPorIdAsync(long id);
}
