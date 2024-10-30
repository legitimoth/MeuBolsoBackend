using AutoMapper;

namespace MeuBolsoBackend;

public class PagamentoService(IPagamentoRepository repository, IMapper mapper, IUnitOfWork unitOfWork, IAuthService authService) : IPagamentoService
{

    public async Task<PagamentoDto> AdicionarAsync(PagamentoManterDto pagamentoManterDto)
    {
        var entity = mapper.Map<PagamentoEntity>(pagamentoManterDto);
        VincularUsuario(entity);
        await repository.AdicionarAsync(entity);
        await unitOfWork.SaveAsync();
        
        return mapper.Map<PagamentoDto>(entity);
    }

    public void Atualizar(PagamentoManterDto PagamentoManterDto)
    {
        throw new NotImplementedException();
    }

    public async Task<PagamentoDto?> RecuperarPorIdAsync(long id)
    {
        var entity = await repository.RecuperarPorIdAsync(id);
        
        return mapper.Map<PagamentoDto>(entity);
    }

    public Task RemoverPorIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<List<PagamentoDto>> RecuperarTodosPorUsuarioIdAsync(long usuarioId)
    {
        throw new NotImplementedException();
    }

    public Task Cancelar(long id)
    {
        throw new NotImplementedException();
    }

    private void VincularUsuario(PagamentoEntity entity)
    {
        entity.UsuarioId = authService.RecuperarId();
        
        foreach (var tag in entity.Tags)
        {
            tag.UsuarioId = entity.UsuarioId;
        }
    }
}