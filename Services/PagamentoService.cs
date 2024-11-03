using AutoMapper;

namespace MeuBolsoBackend;

public class PagamentoService(
    IPagamentoRepository repository, 
    IMapper mapper, 
    IUnitOfWork unitOfWork, 
    IAuthService authService
    ) : IPagamentoService
{

    public async Task<PagamentoDto> AdicionarAsync(PagamentoManterDto pagamentoManterDto)
    {
        var pagamentoEntity = mapper.Map<PagamentoEntity>(pagamentoManterDto);
        pagamentoEntity.UsuarioId = authService.RecuperarId();
        
        await repository.AdicionarAsync(pagamentoEntity);
        await unitOfWork.SaveAsync();
        
        return mapper.Map<PagamentoDto>(pagamentoEntity);
    }

    public async Task AtualizarAsync(long id, PagamentoManterDto pagamentoManterDto)
    {
        var pagamentoEntity = await repository.RecuperarPorIdAsync(id) ?? 
                        throw new NotFoundException(Message.PagamentoNaoEncontrado);
        mapper.Map(pagamentoManterDto, pagamentoEntity);

        await unitOfWork.SaveAsync();
    }

    public async Task<PagamentoDto?> RecuperarPorIdAsync(long id)
    {
        var entity = await repository.RecuperarPorIdAsync(id, true);
        
        return mapper.Map<PagamentoDto>(entity);
    }

    public async Task RemoverPorIdAsync(long id)
    {
        await repository.RemoverPorIdAsync(id);
        await unitOfWork.SaveAsync();
    }

    public async Task<List<PagamentoDto>> RecuperarPorUsuarioIdAsync(long usuarioId)
    {
        var pagamentos = await repository.RecuperarTodosPorUsuarioIdAsync(usuarioId);
        
        return mapper.Map<List<PagamentoDto>>(pagamentos);
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