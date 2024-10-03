namespace MeuBolso.Api.Entities;
public class UsuarioEntity
{
    public long Id { get; set; }
    public required string Nome { get; set; }
    public required string Sobrenome { get; set; }
    public required string Email { get; set; }
    public decimal? Renda { get; set; }
    public string AuthId { get; set; }
}