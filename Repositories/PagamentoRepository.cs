using Microsoft.EntityFrameworkCore;

namespace MeuBolsoBackend;

public class PagamentoRepository(AppDbContext context)  : IPagamentoRepository
{
    private readonly AppDbContext _context = context;

    public async Task<PagamentoEntity> AdicionarAsync(PagamentoEntity pagamentoEntity)
    {
        await _context.Pagamentos.AddAsync(pagamentoEntity);

        return pagamentoEntity;
    }

    public void Atualizar(PagamentoEntity PagamentoEntity)
    {
        _context.Pagamentos.Update(PagamentoEntity);
    }

    public async Task<PagamentoEntity?> RecuperarPorIdAsync(long id)
    {
        return await _context.Pagamentos.FindAsync(id);
    }

    public async Task<List<PagamentoEntity>> RecuperarTodosPorUsuarioIdAsync(long usuarioId)
    {
        return await _context.Pagamentos.Where(p => p.UsuarioId == usuarioId).ToListAsync();
    }

    public async Task RemoverPorIdAsync(long id)
    {
        var pagamento = await _context.Pagamentos.FindAsync(id);

        if(pagamento != null)
        {
            _context.Pagamentos.Remove(pagamento);
        }
    }
}