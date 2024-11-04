using Microsoft.EntityFrameworkCore;

namespace MeuBolsoBackend;

public class CartaoRepository : ICartaoRepository
{
    private readonly DbSet<CartaoEntity> _context;
    private readonly long _usuarioId;
    
    public CartaoRepository(AppDbContext context, IAuthService authService)
    {
        _context = context.Cartoes;
        _usuarioId = authService.RecuperarId();
    }
    
    public async Task<CartaoEntity> AdicionarAsync(CartaoEntity cartaoEntity)
    {
        cartaoEntity.UsuarioId = _usuarioId;
        await _context.AddAsync(cartaoEntity);

        return cartaoEntity;
    }

    public void Atualizar(CartaoEntity cartaoEntity)
    {
        _context.Update(cartaoEntity);
    }

    public async Task<CartaoEntity?> RecuperarPorIdAsync(long id) {
        return await _context
            .FirstOrDefaultAsync(c => c.Id.Equals(id) && c.UsuarioId.Equals(_usuarioId));
    }

    public async Task<bool> ExistePorIdAsync(long id)
    {
        return await _context.AnyAsync(u => u.Id.Equals(id) && u.UsuarioId.Equals(_usuarioId));
    }

    public async Task<bool> ExistePorNomeEFinalAsync(string nome, string final)
    {
        return await _context.AnyAsync(c =>
            c.Nome.ToUpper().Equals(nome.ToUpper()) &&
            c.Final.Equals(final) &&
            c.UsuarioId.Equals(_usuarioId)
        );
    }

    public void RemoverAsync(CartaoEntity cartaoEntity)
    {
        _context.Remove(cartaoEntity);
    }

    public async Task<List<CartaoEntity>> RecuperarTodosAsync()
    {
        return await _context.Where(c => c.UsuarioId.Equals(_usuarioId)).ToListAsync();
    }
}