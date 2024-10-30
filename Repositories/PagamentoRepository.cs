using Microsoft.EntityFrameworkCore;

namespace MeuBolsoBackend;

public class PagamentoRepository(AppDbContext context)  : IPagamentoRepository
{
    public async Task<PagamentoEntity> AdicionarAsync(PagamentoEntity pagamentoEntity)
    {
        await context.Pagamentos.AddAsync(pagamentoEntity);

        return pagamentoEntity;
    }

    public void Atualizar(PagamentoEntity PagamentoEntity)
    {
        context.Pagamentos.Update(PagamentoEntity);
    }

    public async Task<PagamentoEntity?> RecuperarPorIdAsync(long id)
    {
        return await context.Pagamentos
            .Include(p => p.Tags)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<List<PagamentoEntity>> RecuperarTodosPorUsuarioIdAsync(long usuarioId)
    {
        return await context.Pagamentos
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