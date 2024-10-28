namespace MeuBolsoBackend;

public interface IPagamentoRepository
{
    Task <PagamentoEntity> AdicionarAsync(PagamentoEntity pagamentoEntity);
    void Atualizar(PagamentoEntity PagamentoEntity);
    Task<PagamentoEntity?> RecuperarPorIdAsync(long id);
    Task RemoverPorIdAsync(long id);
    Task<List<PagamentoEntity>> RecuperarTodosPorUsuarioIdAsync(long usuarioId);
}