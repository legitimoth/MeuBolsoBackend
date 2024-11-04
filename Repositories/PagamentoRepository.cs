using Microsoft.EntityFrameworkCore;

namespace MeuBolsoBackend;

public class PagamentoRepository : IPagamentoRepository
{
    private readonly DbSet<PagamentoEntity> _context;
    private readonly long _usuarioId;

    public PagamentoRepository(AppDbContext context, IAuthService authService)
    {
        _context = context.Pagamentos;
        _usuarioId = authService.RecuperarId();
    }

    public async Task<PagamentoEntity> AdicionarAsync(PagamentoEntity pagamentoEntity)
    {
        pagamentoEntity.UsuarioId = _usuarioId;

        await _context.AddAsync(pagamentoEntity);

        return pagamentoEntity;
    }

    public void Atualizar(PagamentoEntity pagamentoEntity)
    {
        _context.Update(pagamentoEntity);
    }

    public async Task<PagamentoEntity?> RecuperarPorIdAsync(long id)
    {
        return await _context
            .Include(p => p.Tags)
            .Include(p => p.TipoPagamento)
            .FirstOrDefaultAsync(p => p.Id == id && p.UsuarioId == _usuarioId);
    }

    public async Task<List<PagamentoEntity>> RecuperarTodosAsync()
    {
        return await _context
            .Where(p => p.UsuarioId == _usuarioId)
            .Include(p => p.Tags)
            .Include(p => p.TipoPagamento)
            .ToListAsync();
    }

    public void Remover(PagamentoEntity pagamentoEntity)
    {
        _context.Remove(pagamentoEntity);
    }
}