namespace MeuBolsoBackend;

public interface IPagamentoService
{
    Task <PagamentoDto> AdicionarAsync(PagamentoManterDto pagamentoManterDto);
    void Atualizar(PagamentoManterDto PagamentoManterDto);
    Task<PagamentoDto?> RecuperarPorIdAsync(long id);
    Task RemoverPorIdAsync(long id);
    Task<List<PagamentoDto>> RecuperarTodosPorUsuarioIdAsync(long usuarioId);
    Task Cancelar(long id);
}