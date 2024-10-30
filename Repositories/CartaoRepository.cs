using Microsoft.EntityFrameworkCore;

namespace MeuBolsoBackend;

public class CartaoRepository(AppDbContext context) : ICartaoRepository
{
    public async Task<CartaoEntity> AdicionarAsync(CartaoEntity cartaoEntity)
    {
        await context.Cartoes.AddAsync(cartaoEntity);

        return cartaoEntity;
    }

    public void Atualizar(CartaoEntity cartaoEntity)
    {
        context.Cartoes.Update(cartaoEntity);
    }

    public async Task<CartaoEntity?> RecuperarPorIdAsync(long id) {
        return await context.Cartoes.FindAsync(id);
    }

    public async Task<bool> ExistePorIdAsync(long id)
    {
        return await context.Cartoes.AnyAsync(u => u.Id.Equals(id));
    }

    public async Task<bool> ExistePorNomeEFinalEUsuarioIdAsync(string nome, string final, long usuarioId)
    {
        return await context.Cartoes.AnyAsync(c =>
            c.Nome.ToUpper() == nome.ToUpper() &&
            c.Final.Equals(final) &&
            c.UsuarioId.Equals(usuarioId)
        );
    }

    public async Task RemoverPorIdAsync(long id)
    {
        var cartao = await context.Cartoes.FindAsync(id);

        if(cartao != null)
        {
            context.Cartoes.Remove(cartao);
        }
    }

    public async Task<List<CartaoEntity>> RecuperarTodosPorUsuarioIdAsync(long usuarioId)
    {
        return await context.Cartoes.Where(c => c.UsuarioId == usuarioId).ToListAsync();
    }
}