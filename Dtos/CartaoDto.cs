namespace MeuBolsoBackend;

public record CartaoDto
{
    public long Id { get; set; }
    public required string Nome { get; set; }
    public required string Final { get; set; }
}