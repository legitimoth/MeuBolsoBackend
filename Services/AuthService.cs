using System.Security.Authentication;
using System.Security.Claims;
using System.Text.Json;
using Auth0.ManagementApi;
using Auth0.ManagementApi.Models;
using Microsoft.Extensions.Options;

namespace MeuBolsoBackend;

public class AuthService : IAuthService
{
    private readonly ClaimsPrincipal? UsuarioInfo;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly Auth0Settings _auth0Config;

    public AuthService(IHttpContextAccessor httpContextAccessor, IOptions<Auth0Settings> auth0Settings)
    {
        _httpContextAccessor = httpContextAccessor;
        _auth0Config = auth0Settings.Value;
        UsuarioInfo = _httpContextAccessor.HttpContext?.User ?? throw new AuthenticationException(Message.UsuarioNaoAutenticado);
    }

    public long RecuperarId()
    {
        var usuarioId = UsuarioInfo?.FindFirstValue("meuBolsoId") ?? throw new ClaimNotFoundException(Message.UsuarioSemId);

        return StrUtils.ToLong(usuarioId);
    }

    public string RecuperarEmail()
    {
        return UsuarioInfo?.FindFirstValue("emailAddress") ?? throw new ClaimNotFoundException(Message.UsuarioSemEmail);
    }

    public string RecuperarNome()
    {
        return UsuarioInfo?.FindFirstValue("firstName") ?? "";
    }

    public string RecuperarSobrenome()
    {
        return UsuarioInfo?.FindFirstValue("lastName") ?? "";
    }

    public async Task RegistrarUsuario(long usuarioId)
    {
        var token = await RecuperarApiTokenAsync();
        var managementClient = new ManagementApiClient(token, new Uri($"{_auth0Config.Domain}/api/v2"));
        var auth0Id = UsuarioInfo?.FindFirstValue(ClaimTypes.NameIdentifier) ?? throw new ClaimNotFoundException(Message.UsuarioSemId);
        var updateUserRequest = new UserUpdateRequest
        {
            AppMetadata = new Dictionary<string, long>
            {
                { "meuBolsoId", usuarioId }
            }
        };

        await managementClient.Users.UpdateAsync(auth0Id, updateUserRequest);
    }


    private async Task<string> RecuperarApiTokenAsync()
    {
        var request = new HttpRequestMessage(HttpMethod.Post, $"{_auth0Config.Domain}/oauth/token")
        {
            Content = new FormUrlEncodedContent(new Dictionary<string, string>
            {
                { "grant_type", "client_credentials" },
                { "client_id", _auth0Config.M2M.ClientId },
                { "client_secret", _auth0Config.M2M.ClientSecret },
                { "audience", $"{_auth0Config.Domain}/api/v2/" }
            })
        };

        var response = await new HttpClient().SendAsync(request);

        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();
        var tokenResponse = JsonDocument.Parse(content);
        return tokenResponse.RootElement.GetProperty("access_token").GetString()
            ?? throw new AuthenticationException(Message.Auth0ErroAoGerarTokenApi);
    }
}
