using System.Security.Claims;

namespace MeuBolsoBackend;

public class AuthService : IAuthService
{
    private readonly ClaimsPrincipal? UsuarioInfo;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public AuthService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
        UsuarioInfo = _httpContextAccessor.HttpContext?.User;
    }


    public string RecuperarEmail()
    {
        return (UsuarioInfo?.FindFirst("emailAddress")?.Value) ?? throw new BusinessException(Message.UsuarioSemEmail);
    }

    public string RecuperarNome()
    {
        return UsuarioInfo?.FindFirst("firstName")?.Value ?? "";
    }

    public string RecuperarSobrenome()
    {
        return UsuarioInfo?.FindFirst("lastName")?.Value ?? "";
    }
}
