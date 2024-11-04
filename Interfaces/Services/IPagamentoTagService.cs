namespace MeuBolsoBackend;

public interface IPagamentoTagService
{
    Task AtualizarTags(PagamentoEntity pagamentoEntity, List<TagDto> tagsDto);
    Task AdicionarTags(PagamentoEntity pagamentoEntity, List<TagDto> tagsDto);
    void RemoverTagsOrfas(List<TagEntity> tagsRemovidas);
}