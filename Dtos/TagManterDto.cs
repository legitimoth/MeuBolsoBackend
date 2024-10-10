namespace MeuBolsoBackend;

public record TagManterDto
{
    public required string Nome { get; set; }
    public string? Cor { get; set; }
}
