namespace MeuBolsoBackend;

public interface IUsuarioRepository
{
    Task<UsuarioEntity> AdicionarAsync(UsuarioEntity usuario);
    Task<UsuarioEntity?> RecuperarPorEmailAsync(string email);
    Task<UsuarioEntity?> RecuperarPorIdAsync(long id, bool nullable);
    Task<bool> ExistePorIdAsync(long id);
}
