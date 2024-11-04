namespace MeuBolsoBackend;

public interface IPagamentoRepository
{
    Task <PagamentoEntity> AdicionarAsync(PagamentoEntity pagamentoEntity);
    void Atualizar(PagamentoEntity pagamentoEntity);
    Task<PagamentoEntity?> RecuperarPorIdAsync(long id);
    Task<List<PagamentoEntity>> RecuperarTodosAsync();
    void Remover(PagamentoEntity pagamentoEntity);
}