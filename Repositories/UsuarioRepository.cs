using Microsoft.EntityFrameworkCore;

namespace MeuBolsoBackend;

public class UsuarioRepository(AppDbContext context) : IUsuarioRepository
{
    private readonly AppDbContext _context = context;

    public async Task<UsuarioEntity> AdicionarAsync(UsuarioEntity usuarioEntity)
    {
        await _context.Usuarios.AddAsync(usuarioEntity);

        return usuarioEntity;
    }

    public async Task<UsuarioEntity?> RecuperarPorIdAsync(long id) {
        return await _context.Usuarios.FindAsync(id);
    }

    public async Task<UsuarioEntity?> RecuperarPorEmailAsync(string email)
    {
        return await _context.Usuarios.FirstOrDefaultAsync(u => u.Email.Equals(email));
    }

    public async Task<bool> ExistePorIdAsync(long id)
    {
        return await _context.Usuarios.AnyAsync(u => u.Id.Equals(id));
    }
}
