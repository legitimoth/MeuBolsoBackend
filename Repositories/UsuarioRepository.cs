using Microsoft.EntityFrameworkCore;

namespace MeuBolsoBackend;

public class UsuarioRepository(AppDbContext context) : IUsuarioRepository
{
    public async Task<UsuarioEntity> AdicionarAsync(UsuarioEntity usuarioEntity)
    {
        await context.Usuarios.AddAsync(usuarioEntity);

        return usuarioEntity;
    }

    public async Task<UsuarioEntity?> RecuperarPorIdAsync(long id, bool nullable = true) {
        var usuario = await context.Usuarios.FindAsync(id);

        if (usuario == null && nullable == false)
        {
            throw new NotFoundException(Message.UsuarioNaoEncontrado);
        }
        
        return usuario;
    }

    public async Task<UsuarioEntity?> RecuperarPorEmailAsync(string email)
    {
        return await context.Usuarios.FirstOrDefaultAsync(u => u.Email.Equals(email));
    }

    public async Task<bool> ExistePorIdAsync(long id)
    {
        return await context.Usuarios.AnyAsync(u => u.Id.Equals(id));
    }
}
