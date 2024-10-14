namespace MeuBolsoBackend;

public interface IAuthService
{
    string RecuperarEmail();
    long RecuperarId();
    string RecuperarNome();
    string RecuperarSobrenome();
    Task RegistrarUsuario(long usuarioId);
}
