using System.ComponentModel.DataAnnotations;

namespace MeuBolso.Api.Dtos;

public record class UsuarioManterDto
{
    public required string Nome { get; set; }
    public required string Sobrenome { get; set; }
    public required string Email { get; set; }
    public decimal? Renda { get; set; }
}
