using AutoMapper;

namespace MeuBolsoBackend;

public class PagamentoService(
    IPagamentoRepository repository, 
    IMapper mapper, 
    IUnitOfWork unitOfWork,
    IPagamentoTagService pagamentoTagService
    ) : IPagamentoService
{

    public async Task<PagamentoDto> AdicionarAsync(PagamentoManterDto pagamentoManterDto)
    {
        var pagamentoEntity = mapper.Map<PagamentoEntity>(pagamentoManterDto);
        
        await pagamentoTagService.AdicionarTags(pagamentoEntity, pagamentoManterDto.Tags);
        await repository.AdicionarAsync(pagamentoEntity);
        await unitOfWork.SaveAsync();

        return await RecuperarPorIdAsync(pagamentoEntity.Id);
    }

    public async Task AtualizarAsync(long id, PagamentoManterDto pagamentoManterDto)
    {
        var pagamentoEntity = await repository.RecuperarPorIdAsync(id) ?? 
                        throw new NotFoundException(Message.PagamentoNaoEncontrado);
        
        mapper.Map(pagamentoManterDto, pagamentoEntity);
        await pagamentoTagService.AtualizarTags(pagamentoEntity, pagamentoManterDto.Tags);
        await unitOfWork.SaveAsync();
    }

    public async Task<PagamentoDto> RecuperarPorIdAsync(long id)
    {
        var entity = await repository.RecuperarPorIdAsync(id)
            ?? throw new NotFoundException(Message.PagamentoNaoEncontrado);
        
        return mapper.Map<PagamentoDto>(entity);
    }

    public async Task RemoverPorIdAsync(long id)
    {
        var pagamentoEntity = await repository.RecuperarPorIdAsync(id) ??
                              throw new NotFoundException(Message.PagamentoNaoEncontrado);
        
        pagamentoTagService.RemoverTagsOrfas(pagamentoEntity.Tags);
        repository.Remover(pagamentoEntity);
        
        await unitOfWork.SaveAsync();
    }

    public async Task<List<PagamentoDto>> RecuperarTodosAsync()
    {
        var pagamentosEntity = await repository.RecuperarTodosAsync();
        
        return mapper.Map<List<PagamentoDto>>(pagamentosEntity);
    }

    public async Task CancelarAsync(long id)
    {
        var pagamentoEntity = await repository.RecuperarPorIdAsync(id)
                              ?? throw new NotFoundException(Message.PagamentoNaoEncontrado);
        
        pagamentoEntity.Cancelado = !pagamentoEntity.Cancelado;
        
        repository.Atualizar(pagamentoEntity);
        await unitOfWork.SaveAsync();
    }
}