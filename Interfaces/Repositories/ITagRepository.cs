namespace MeuBolsoBackend;

public interface ITagRepository
{
    Task AdicionarAsync(List<TagEntity> tagsEntity);
    Task<List<TagEntity>> RecuperarTodosAsync();
    Task<List<TagEntity>> RecuperarPorNomesAsync(List<string> nomes);
    Task<bool> VerificarDuplicidade(string nome);
    void Remover(List<TagEntity> tagsEntity);
}