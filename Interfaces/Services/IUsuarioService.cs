namespace MeuBolsoBackend;

public interface IUsuarioService
{
    Task<UsuarioDto> AdicionarAsync();
    Task<UsuarioDto> RecuperarPorIdAsync(long id);
}
