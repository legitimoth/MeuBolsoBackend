namespace MeuBolsoBackend;
public class Auth0Settings
{
    public string Domain { get; set; } = string.Empty;
    public Auth0ApiSettings Api { get; set; } = new Auth0ApiSettings();
    public Auth0M2MSettings M2M { get; set; } = new Auth0M2MSettings();
}

public class Auth0ApiSettings
{
    public string Audience { get; set; } = string.Empty;
    public string ClientId { get; set; } = string.Empty;
    public string ClientSecret { get; set; } = string.Empty;
}

public class Auth0M2MSettings
{
    public string ClientId { get; set; } = string.Empty;
    public string ClientSecret { get; set; } = string.Empty;
}