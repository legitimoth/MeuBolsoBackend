namespace MeuBolsoBackend;

public class PagamentoTagService(IPagamentoRepository pagamentoRepository, ITagRepository tagRepository) : IPagamentoTagService
{
    public async Task AtualizarTags(PagamentoEntity pagamentoEntity, List<TagDto> tagsDto)
    {
        // Remover
        RemoverTags(pagamentoEntity, tagsDto);
        
        // Adicionar
        await AdicionarTags(pagamentoEntity, tagsDto);
    }

    public async Task AdicionarTags(PagamentoEntity pagamentoEntity, List<TagDto> tagsDto)
    {
        // Recupera as tags ja existentes no banco
        var tagsExistentes = await tagRepository.RecuperarPorNomesAsync(tagsDto.Select(x => x.Nome).ToList());
        var tagsNovas = tagsDto
            .Where(t => tagsExistentes.All(x => x.Nome != t.Nome))
            .Select(t => new TagEntity { Nome = t.Nome } )
            .ToList();

        // Adiciona no banco as Tags novas
        await tagRepository.AdicionarAsync(tagsNovas);
        
        // Adiciona as Tags ao pagamento.
        pagamentoEntity.Tags.AddRange(tagsExistentes);
        pagamentoEntity.Tags.AddRange(tagsNovas);
    }

    private void RemoverTags(PagamentoEntity pagamentoEntity, List<TagDto> tagsDto)
    {
        // Separa as tags removidas
        var tagsRemovidas = pagamentoEntity.Tags
            .Where(te => !tagsDto.Any(td => td.Nome.Equals(te.Nome)))
            .ToList();
        
        // Remove as tags no pagamento
        pagamentoEntity.Tags.RemoveAll(t => tagsRemovidas.Any(tr => tr.Id.Equals(t.Id)));
        
        // Remove do banco caso não esteja sendo utilizada
        RemoverTagsOrfas(tagsRemovidas);
        
        // Remove as tag novas que ja estão no pagamento
        tagsDto.RemoveAll(t => pagamentoEntity.Tags.Any(te => te.Nome.Equals(t.Nome)));
    }

    public void RemoverTagsOrfas(List<TagEntity> tagsRemovidas)
    {
        var tagsOrfas = tagsRemovidas
            .Where(tr => tr.Pagamentos.Count <= 1)
            .ToList();
        tagRepository.Remover(tagsOrfas);
    }
}