namespace MeuBolso.Api.Dtos;

public record class UsuarioDto
{
    public long Id { get; set; }
    public required string Nome { get; set; }
    public required string Sobrenome { get; set; }
    public required string Email { get; set; }
}
