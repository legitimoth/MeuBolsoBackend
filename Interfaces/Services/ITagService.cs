namespace MeuBolsoBackend;

public interface ITagService
{
    Task<TagDto> AdicionarAsync(TagManterDto tagManterDto);
    Task AtualizarAsync(long id, TagManterDto tagManterDto);
    Task<List<TagDto>> RecuperarTodasPorUsuarioIdAsync(long usuarioId);
    Task<TagDto> RecuperarPorIdAsync(long id);
    Task RemoverPorIdAsync(long id);
}
