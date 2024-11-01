using Microsoft.EntityFrameworkCore;

namespace MeuBolsoBackend;

public class PagamentoRepository(AppDbContext context)  : IPagamentoRepository
{
    public async Task<PagamentoEntity> AdicionarAsync(PagamentoEntity pagamentoEntity)
    {
        await context.Pagamentos.AddAsync(pagamentoEntity);

        return pagamentoEntity;
    }

    public void Atualizar(PagamentoEntity pagamentoEntity)
    {
        context.Pagamentos.Update(pagamentoEntity);
    }

    public async Task<PagamentoEntity?> RecuperarPorIdAsync(long id, bool incluirTags)
    {
        var query = context.Pagamentos.AsQueryable();
        query.Include(p => p.Tags).Include(p => p.TipoPagamento);
        
        if (incluirTags)
        {
            query = query.Include(p => p.Tags);
        }

        return await query.FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<List<PagamentoEntity>> RecuperarTodosPorUsuarioIdAsync(long usuarioId)
    {
        return await context.Pagamentos
            .Include(p => p.TipoPagamento)
            .Include(p => p.Tags)
            .Where(p => p.UsuarioId == usuarioId)
            .ToListAsync();
    }

    public async Task RemoverPorIdAsync(long id)
    {
        var pagamento = await context.Pagamentos.FindAsync(id);

        if(pagamento != null)
        {
            context.Pagamentos.Remove(pagamento);
        }
    }
}