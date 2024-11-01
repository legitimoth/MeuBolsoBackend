namespace MeuBolsoBackend;

public interface IPagamentoRepository
{
    Task <PagamentoEntity> AdicionarAsync(PagamentoEntity pagamentoEntity);
    void Atualizar(PagamentoEntity pagamentoEntity);
    Task<PagamentoEntity?> RecuperarPorIdAsync(long id, bool incluirTags = false);
    Task RemoverPorIdAsync(long id);
    Task<List<PagamentoEntity>> RecuperarTodosPorUsuarioIdAsync(long usuarioId);
}