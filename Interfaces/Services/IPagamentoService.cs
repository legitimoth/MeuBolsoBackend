namespace MeuBolsoBackend;

public interface IPagamentoService
{
    Task <PagamentoDto> AdicionarAsync(PagamentoManterDto pagamentoManterDto);
    Task AtualizarAsync(long id, PagamentoManterDto pagamentoManterDto);
    Task<PagamentoDto?> RecuperarPorIdAsync(long id);
    Task RemoverPorIdAsync(long id);
    Task<List<PagamentoDto>> RecuperarPorUsuarioIdAsync(long usuarioId);
    Task CancelarAsync(long id);
}