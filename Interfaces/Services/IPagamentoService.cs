namespace MeuBolsoBackend;

public interface IPagamentoService
{
    Task <PagamentoDto> AdicionarAsync(PagamentoAdicionarDto pagamentoAdicionarDto);
    Task AtualizarAsync(long id, PagamentoAtualizarDto pagamentoAtualizarDto);
    Task<PagamentoDto?> RecuperarPorIdAsync(long id);
    Task RemoverPorIdAsync(long id);
    Task<List<PagamentoDto>> RecuperarPorUsuarioIdAsync();
    Task Cancelar(long id);
}